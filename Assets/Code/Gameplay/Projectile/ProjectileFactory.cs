using System;
using AbilityMadness.Code.Extensions;
using AbilityMadness.Code.Gameplay.Projectile.Factory;
using Random = UnityEngine.Random;

namespace AbilityMadness.Code.Gameplay.Projectile
{
    public class ProjectileFactory : IProjectileFactory
    {
        private IDirectionalFactory _directionalFactory;
        private IThrowableFactory _throwableFactory;

        public ProjectileFactory(IDirectionalFactory directionalFactory, IThrowableFactory throwableFactory)
        {
            _throwableFactory = throwableFactory;
            _directionalFactory = directionalFactory;
        }

        public GameEntity CreateProjectile(ProjectileTypeId type, GameEntity weapon, GameEntity bullet, GameEntity owner, int index)
        {
            return type switch
            {
                ProjectileTypeId.Directional => CreateDirectionalProjectile(weapon, bullet, owner, index),
                ProjectileTypeId.Throwable => CreateThrowableProjectile(weapon, bullet, owner, index),
                _ => throw new ArgumentOutOfRangeException()
            };
        }

        private GameEntity CreateDirectionalProjectile(GameEntity weapon, GameEntity bullet, GameEntity owner, int index)
        {
            var spawnCount = weapon.SpawnAmount + bullet.SpawnAmount;
            var direction = VectorExtensions.GetArcDirection(weapon.Direction, spawnCount, index);
            var directionalRequest = new DirectionalRequest
            {
                type = bullet.BulletTypeId,
                ownerId = owner.Id,
                producerId = weapon.Id,
                assetRef = bullet.AssetReference,
                position = weapon.WeaponPivot.position,
                direction = direction,
                team = weapon.Team
            };

            return _directionalFactory.CreateDirectional(directionalRequest);
        }

        private GameEntity CreateThrowableProjectile(GameEntity weapon, GameEntity bullet, GameEntity owner, int index)
        {
            var targetPosition = weapon.TargetPosition + Random.insideUnitCircle.ToVector3();

            var throwableRequest = new ThrowableRequest
            {
                type = bullet.BulletTypeId,
                ownerId = owner.Id,
                producerId = weapon.Id,
                assetRef = bullet.AssetReference,
                position = weapon.WeaponPivot.position,
                team = weapon.Team,
                targetPosition = targetPosition
            };

            return _throwableFactory.CreateThrowable(throwableRequest);
        }
    }
}
