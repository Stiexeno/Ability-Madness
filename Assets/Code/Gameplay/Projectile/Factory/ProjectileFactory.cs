using AbilityMadness.Code.Common;
using AbilityMadness.Code.Extensions;
using AbilityMadness.Code.Gameplay.Health;
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

        public GameEntity CreateFireball(int abilityId, Vector3 position, Vector3 direction, Team team)
        {
            return CreateEntity.Empty()
                .With(x => x.isProjectile = true)
                .AddId(_identifierService.Next())
                .AddAbilityProducerId(abilityId)
                .AddViewPath(Constants.Prefabs.Projectiles.Fireball)
                .AddTeam(team)

                .SetLifetime(LifeTime)

                .With(x => x.isTransformMovement = true)
                .AddDirection(direction)
                .AddWorldPosition(position)
                .With(x => x.isFaceToDirection = true)

                .AddDamage(10)
                .CollectTargetsWithSphereCast(0.3f)

                .AddEffectViewPath(Constants.Prefabs.Effects.FireballHitEffect);
        }

        public GameEntity CreateTornado(int abilityId, Vector3 position, Vector3 direction, Team team)
        {
            return CreateEntity.Empty()
                .With(x => x.isProjectile = true)
                .AddId(_identifierService.Next())
                .AddAbilityProducerId(abilityId)
                .AddViewPath(Constants.Prefabs.Projectiles.Tornado)
                .AddTeam(team)

                .SetLifetime(LifeTime)

                .With(x => x.isTransformMovement = true)
                .AddDirection(direction)
                .AddWorldPosition(position)

                .AddDamage(10)
                .CollectTargetsWithSphereCast(0.3f)

                .AddEffectViewPath(Constants.Prefabs.Effects.FireballHitEffect);
        }
    }
}
