using AbilityMadness.Code.Extensions;
using AbilityMadness.Code.Gameplay.Projectile.Factory;
using Entitas;
using UnityEngine;

namespace AbilityMadness.Code.Gameplay.Weapons.Systems
{
    public class CreateProjectileRequestSystem : IExecuteSystem
    {
        private IGroup<GameEntity> _weapons;
        private IProjectileFactory _projectileFactory;
        private readonly IGroup<GameEntity> _owners;
        private GameContext _gameContext;
        private IGroup<GameEntity> _bullets;

        public CreateProjectileRequestSystem(GameContext gameContext, IProjectileFactory projectileFactory)
        {
            _gameContext = gameContext;
            _projectileFactory = projectileFactory;
            _weapons = gameContext.GetGroup(GameMatcher
                .AllOf(
                    GameMatcher.Weapon,
                    GameMatcher.Shot,
                    GameMatcher.Direction,
                    GameMatcher.AmmoIndex,
                    GameMatcher.Ready,
                    GameMatcher.Spread,
                    GameMatcher.WeaponPivot));

            _owners = gameContext.GetGroup(GameMatcher
                .AllOf(
                    GameMatcher.Id,
                    GameMatcher.WorldPosition));

            _bullets = gameContext.GetGroup(GameMatcher
                .AllOf(
                    GameMatcher.Bullet,
                    GameMatcher.BulletTypeId,
                    GameMatcher.BulletIndex,
                    GameMatcher.TargetId,
                    GameMatcher.AssetReference));
        }

        public void Execute()
        {
            foreach (var weapon in _weapons)
            {
                var owner = _gameContext.GetEntityWithId(weapon.OwnerId);

                if (_owners.ContainsEntity(owner))
                {
                    var bullets = _gameContext.GetEntitiesWithTargetId(weapon.Id);

                    foreach (var bullet in bullets)
                    {
                        if (_bullets.ContainsEntity(bullet) == false)
                            continue;

                        if (bullet.BulletIndex == weapon.AmmoIndex)
                        {
                            CreateProjectile(weapon, bullet, owner);
                        }
                    }
                }
            }
        }

        private void CreateProjectile(GameEntity weapon, GameEntity bullet, GameEntity owner)
        {
            var spawnCount = weapon.SpawnAmount + bullet.SpawnAmount;

            for (int i = 0; i < spawnCount; i++)
            {
                var direction = VectorExtensions.GetArcDirection(weapon.Direction, spawnCount, i);
                var projectileScheme = new ProjectileRequest
                {
                    type = bullet.BulletTypeId,
                    ownerId = owner.Id,
                    producerId = weapon.Id,
                    assetRef = bullet.AssetReference,
                    position = weapon.WeaponPivot.position,
                    direction = direction,
                    team = weapon.Team
                };

                _projectileFactory.CreateProjectile(projectileScheme);
            }
        }
    }
}
