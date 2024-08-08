using System;
using AbilityMadness.Code.Common;
using AbilityMadness.Code.Extensions;
using AbilityMadness.Code.Gameplay.Health;
using AbilityMadness.Code.Gameplay.Lifetime;
using AbilityMadness.Code.Gameplay.Movement;
using AbilityMadness.Code.Gameplay.TargetCollection;
using AbilityMadness.Code.Gameplay.Weapons;
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

        public GameEntity CreateProjectile(ProjectileScheme scheme)
        {
            switch (scheme.type)
            {
                case BulletTypeId.Unkonwn:
                    throw new ArgumentOutOfRangeException();
                case BulletTypeId.Regular:
                    return CreateRegularProjectile(scheme);
                case BulletTypeId.Hard:
                    return CreateHardProjectile(scheme);
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }

        // Requests

        public GameEntity CreateProjectileRequest(
            BulletTypeId type,
            int abilityId,
            Vector3 position,
            Vector3 direction,
            Team team,
            int bulletDamage,
            float spread)
        {
            var projectileScheme = new ProjectileScheme
            {
                type = type,
                producerId = abilityId,
                position = position,
                direction = direction,
                team = team,
                damage = bulletDamage,
                movementSpeed = 0.15f,
                spawnCount = 1,
                spread = spread
            };

            return CreateEntity.Empty()
                .AddId(_identifierService.Next())
                .AddProjectileRequest(projectileScheme);

        }

        // Implementations

        private GameEntity CreateRegularProjectile(ProjectileScheme scheme)
        {
            return CreateEmptyProjectile(scheme)
                .AddViewPath(Constants.Prefabs.Projectiles.Bullet)
                .CollectTargetsWithSphereCast(0.3f)
                .With(x => x.isFaceToDirection = true)
                .SetForwardMovement()

                .AddEffectViewPath(Constants.Prefabs.Effects.FireballHitEffect);
        }

        private GameEntity CreateHardProjectile(ProjectileScheme scheme)
        {
            return CreateEmptyProjectile(scheme)
                .AddViewPath(Constants.Prefabs.Projectiles.Fireball)
                .CollectTargetsWithSphereCast(0.3f)
                .With(x => x.isFaceToDirection = true)
                .SetForwardMovement()

                .AddEffectViewPath(Constants.Prefabs.Effects.FireballHitEffect);
        }

        private GameEntity CreateEmptyProjectile(ProjectileScheme scheme)
        {
            return CreateEntity.Empty()
                .AddId(_identifierService.Next())
                .With(x => x.isProjectile = true)
                .AddProducerId(scheme.producerId)
                .AddDamage(scheme.damage)
                .AddTeam(scheme.team)

                .SetLifetime(LifeTime)
                .With(x => x.isAlive = true)

                .With(x => x.isTransformMovement = true)
                .AddDirection(scheme.direction)
                .AddWorldPosition(scheme.position)
                .AddMovementSpeed(scheme.movementSpeed);
        }
    }
}
