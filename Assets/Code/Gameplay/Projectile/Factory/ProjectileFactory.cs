using System;
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

        public GameEntity CreateProjectile(ProjectileTypeId type, int abilityId, Vector3 position, Vector3 direction, Team team)
        {
            switch (type)
            {
                case ProjectileTypeId.Unknown:
                    throw new ArgumentOutOfRangeException(nameof(type), type, null);
                case ProjectileTypeId.Fireball:
                    return CreateFireball(abilityId, position, direction, team);
                case ProjectileTypeId.Tornado:
                    return CreateTornado(abilityId, position, direction, team);
                default:
                    throw new ArgumentOutOfRangeException(nameof(type), type, null);
            }
        }

        // Requests

        public GameEntity CreateProjectileRequest(ProjectileTypeId type, int abilityId, Vector3 position, Vector3 direction, Team team)
        {
            return CreateEntity.Empty()
                .AddId(_identifierService.Next())

                .With(x => x.isProducedByAbility = true)
                .AddProducerId(abilityId)
                .AddRequestProjectile(type)

                .AddSpawnAmount(1)
                .AddWorldPosition(position)
                .AddDirection(direction)
                .AddTeam(team);
        }

        // Implementations

        public GameEntity CreateFireball(int abilityId, Vector3 position, Vector3 direction, Team team)
        {
            return CreateEmptyProjectile(abilityId, position, direction, team)
                .AddProjectileTypeId(ProjectileTypeId.Fireball)
                .AddViewPath(Constants.Prefabs.Projectiles.Fireball)
                .AddDamage(10)
                .CollectTargetsWithSphereCast(0.3f)
                .With(x => x.isFaceToDirection = true)

                .AddEffectViewPath(Constants.Prefabs.Effects.FireballHitEffect);
        }

        public GameEntity CreateTornado(int abilityId, Vector3 position, Vector3 direction, Team team)
        {
            return CreateEmptyProjectile(abilityId, position, direction, team)
                .AddProjectileTypeId(ProjectileTypeId.Tornado)
                .AddViewPath(Constants.Prefabs.Projectiles.Tornado)
                .AddDamage(10)
                .CollectTargetsWithSphereCast(0.3f)

                .AddEffectViewPath(Constants.Prefabs.Effects.FireballHitEffect);
        }

        private GameEntity CreateEmptyProjectile(int abilityId, Vector3 position, Vector3 direction, Team team)
        {
            return CreateEntity.Empty()
                .AddId(_identifierService.Next())
                .With(x => x.isProjectile = true)
                .With(x => x.isProducedByAbility = true)
                .AddProducerId(abilityId)

                .AddTeam(team)

                .SetLifetime(LifeTime)
                .With(x => x.isAlive = true)

                .With(x => x.isTransformMovement = true)
                .AddDirection(direction)
                .AddWorldPosition(position);
        }
    }
}
