using AbilityMadness.Code.Common;
using AbilityMadness.Code.Extensions;
using AbilityMadness.Code.Gameplay.Lifetime;
using AbilityMadness.Code.Gameplay.Movement;
using AbilityMadness.Code.Gameplay.TargetCollection;
using AbilityMadness.Code.Gameplay.Weapons;
using AbilityMadness.Code.Infrastructure.Services.Identifiers;
using AbilityMadness.Infrastructure.Services.Configs;

namespace AbilityMadness.Code.Gameplay.Projectile.Factory
{
    public class ProjectileFactory : IProjectileFactory
    {
        private IIdentifierService _identifierService;
        private IConfigsService _configsService;

        public ProjectileFactory(IIdentifierService identifierService, IConfigsService configsService)
        {
            _configsService = configsService;
            _identifierService = identifierService;
        }

        public GameEntity CreateProjectile(ProjectileRequest request)
        {
            var bulletConfig = _configsService.GetBulletConfig(request.type);
            return request.type switch
            {
                _ => CreateDefaultProjectile(request, bulletConfig.projectileSetup)
            };
        }

        // Implementations

        private GameEntity CreateDefaultProjectile(ProjectileRequest request, ProjectileSetup setup)
        {
            return CreateEmptyProjectile(request, setup)
                .CollectTargetsWithSphereCast(0.3f)
                .With(x => x.isFaceToDirection = true)
                .SetForwardMovement();
        }

        private GameEntity CreateEmptyProjectile(ProjectileRequest request, ProjectileSetup setup)
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
                .AddDamage(setup.damage)
                .AddTeam(request.team)
                .AddWorldPosition(request.position)
                .AddDirection(direction)
                .AddEffectViewPath(Constants.Prefabs.Effects.BulletHitEffect)

                .With(x => x.isAlive = true)
                .With(x => x.isTransformMovement = true)
                .SetLifetime(setup.lifeTime)
                .AddMovementSpeed(setup.movementSpeed)

                .With(x => x.AddPierce(setup.pierce), when: setup.pierce > 0)
                .With(x => x.AddPiercedAmount(0), when: setup.pierce > 0)

                .With(x => x.AddRicochetHitCount(setup.ricochet), when: setup.ricochet > 0);
        }
    }
}
