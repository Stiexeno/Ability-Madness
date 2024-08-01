using AbilityMadness.Code.Common;
using AbilityMadness.Code.Extensions;
using AbilityMadness.Code.Gameplay.Lifetime;
using AbilityMadness.Code.Gameplay.TargetCollection;
using AbilityMadness.Code.Infrastructure.Services.Identifiers;
using UnityEngine;

namespace AbilityMadness.Code.Gameplay.Projectile.Factory
{
    public class ProjectileFactory : IProjectileFactory
    {
        private const float LifeTime = 5f;

        private IIdentifierService _identifierService;

        public ProjectileFactory(IIdentifierService identifierService)
        {
            _identifierService = identifierService;
        }

        public GameEntity CreateFireball(Vector3 position, Vector3 direction)
        {
            return CreateEntity.Empty()
                .With(x => x.isProjectile = true)
                .AddId(_identifierService.Next())
                .AddViewPath(Constants.Prefabs.Projectiles.Fireball)

                .SetLifetime(LifeTime)

                .With(x => x.isTransformMovement = true)
                .AddWorldPosition(position)
                .AddDirection(direction)
                .AddMovementSpeed(0.05f)

                .AddDamage(10)
                .CollectTargetsWithSphereCast(0.3f)

                .AddEffectViewPath(Constants.Prefabs.Effects.FireballHitEffect);
        }
    }
}
