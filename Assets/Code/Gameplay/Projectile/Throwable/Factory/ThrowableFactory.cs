using AbilityMadness.Code.Common;
using AbilityMadness.Code.Extensions;
using AbilityMadness.Code.Infrastructure.Configs;
using AbilityMadness.Code.Infrastructure.Identifiers;
using UnityEngine;

namespace AbilityMadness.Code.Gameplay.Projectile.Factory
{
    public class ThrowableFactory : IThrowableFactory
    {
        private IIdentifierService _identifierService;
        private IConfigsService _configsService;

        public ThrowableFactory(IIdentifierService identifierService, IConfigsService configsService)
        {
            _configsService = configsService;
            _identifierService = identifierService;
        }

        public GameEntity CreateThrowable(ThrowableRequest request)
        {
            var bulletConfig = _configsService.GetBulletConfig(request.type);
            return request.type switch
            {
                _ => CreateDefaultThrowable(request, bulletConfig.throwableSetup)
            };
        }

        private GameEntity CreateDefaultThrowable(ThrowableRequest request, ThrowableSetup setup)
        {
            var distance = Vector3.Distance(request.position, request.targetPosition);
            var normalizedValue = Mathf.Clamp01(distance / setup.range);

            return CreateEntity.Empty()
                .AddId(_identifierService.Next())
                .With(x => x.isProjectile = true)
                .With(x => x.isThrowable = true)
                .AddViewReference(request.assetRef)
                .AddProducerId(request.producerId)
                .AddOwnerId(request.ownerId)
                .AddTeam(request.team)
                .AddWorldPosition(request.position)

                .AddEffectSetups(setup.effectSetups)

                .With(x => x.isAlive = true)
                .With(x => x.isTransformMovement = true)
                .AddDistanceTraveled(0f)
                .AddLastPosition(request.position)
                .AddRange(setup.range)

                .AddTargetPosition(request.targetPosition)
                .AddStartPosition(request.position)
                .AddVelocity(Vector3.zero)
                .AddMaxHeight(normalizedValue * setup.maxHeight)
                .AddMovementSpeed(Mathf.Clamp((normalizedValue), 0.7f, 1f) * setup.movementSpeed);
        }
    }
}
