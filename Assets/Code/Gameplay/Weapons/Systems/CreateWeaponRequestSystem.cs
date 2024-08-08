using System;
using AbilityMadness.Code.Gameplay.Projectile.Factory;
using Entitas;

namespace AbilityMadness.Code.Gameplay.Weapons.Systems
{
    public class CreateWeaponRequestSystem : IExecuteSystem
    {
        private IGroup<GameEntity> _weapons;
        private IProjectileFactory _projectileFactory;
        private readonly IGroup<GameEntity> _owners;
        private GameContext _gameContext;
        private IGroup<GameEntity> _bullets;

        public CreateWeaponRequestSystem(GameContext gameContext, IProjectileFactory projectileFactory)
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
                    GameMatcher.Spread));

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
                    GameMatcher.Damage));
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
                        if (bullet.BulletIndex == weapon.AmmoIndex)
                        {
                            _projectileFactory.CreateProjectileRequest(
                                bullet.BulletTypeId,
                                weapon.Id,
                                owner.WorldPosition,
                                weapon.Direction,
                                weapon.Team,
                                bullet.Damage,
                                weapon.Spread);
                        }
                    }
                }
            }
        }
    }
}
