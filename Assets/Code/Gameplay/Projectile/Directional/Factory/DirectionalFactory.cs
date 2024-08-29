using AbilityMadness.Code.Common;
using AbilityMadness.Code.Extensions;
using AbilityMadness.Code.Gameplay.Movement;
using AbilityMadness.Code.Gameplay.TargetCollection;
using AbilityMadness.Code.Gameplay.Weapons;
using AbilityMadness.Code.Infrastructure.Configs;
using AbilityMadness.Code.Infrastructure.Identifiers;

namespace AbilityMadness.Code.Gameplay.Projectile.Factory
{
    public class DirectionalFactory : IDirectionalFactory
    {
        private IIdentifierService _identifierService;
        private IConfigsService _configsService;

        public DirectionalFactory(
            IIdentifierService identifierService,
            IConfigsService configsService)
        {
            _configsService = configsService;
            _identifierService = identifierService;
        }

        public GameEntity CreateDirectional(DirectionalRequest request)
        {
            var bulletConfig = _configsService.GetBulletConfig(request.type);
            return request.type switch
            {
                _ => CreateDefaultProjectile(request, bulletConfig.projectileSetup)
            };
        }

        // Implementations

        private GameEntity CreateDefaultProjectile(DirectionalRequest request, ProjectileSetup setup)
        {
            return CreateEmptyDirectional(request, setup)
                .AddMovementSpeed(setup.movementSpeed)
                .CollectTargetsWithSphereCast(0.3f)
                .With(x => x.isFaceToDirection = true)
                .SetForwardMovement();
        }

        private GameEntity CreateEmptyDirectional(DirectionalRequest request, ProjectileSetup setup)
        {
            var direction = ProjectileExtensions.CalculateSpreadDirection(
                request.spread + setup.spread,
                request.direction);

            return CreateEntity.Empty()
                .AddId(_identifierService.Next())
                .With(x => x.isProjectile = true)
                .AddViewReference(request.assetRef)
                .AddProducerId(request.producerId)
                .AddOwnerId(request.ownerId)
                .AddTeam(request.team)
                .AddWorldPosition(request.position)
                .AddDirection(direction)

                .AddEffectSetups(setup.effectSetups)
                .AddStatusSetups(setup.statusSetups)

                .With(x => x.isAlive = true)
                .With(x => x.isTransformMovement = true)
                .AddDistanceTraveled(0f)
                .AddLastPosition(request.position)
                .AddRange(setup.range)

                .With(x => x.AddPierce(setup.pierce), when: setup.pierce > 0)
                .With(x => x.AddPiercedAmount(0), when: setup.pierce > 0)

                .With(x => x.AddRicochetHitCount(setup.ricochet), when: setup.ricochet > 0);
        }
    }
}
