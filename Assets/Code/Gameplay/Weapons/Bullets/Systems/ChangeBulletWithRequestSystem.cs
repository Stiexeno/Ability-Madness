using System;
using System.Collections.Generic;
using AbilityMadness.Code.Gameplay.Weapons.Bullets.Factory;
using Entitas;

namespace AbilityMadness.Code.Gameplay.Weapons.Bullets.Systems
{
    public class ChangeBulletWithRequestSystem : IExecuteSystem
    {
        private readonly List<GameEntity> _buffer = new(32);

        private IGroup<GameEntity> _bulletRequests;
        private IGroup<GameEntity> _bullets;
        private IBulletFactory _bulletFactory;

        public ChangeBulletWithRequestSystem(GameContext gameContext, IBulletFactory bulletFactory)
        {
            _bulletFactory = bulletFactory;
            _bulletRequests = gameContext.GetGroup(GameMatcher
                .AllOf(
                    GameMatcher.BulletChangeRequest,
                    GameMatcher.BulletTypeId,
                    GameMatcher.BulletIndex));

            _bullets = gameContext.GetGroup(GameMatcher
                .AllOf(
                    GameMatcher.Bullet,
                    GameMatcher.BulletIndex,
                    GameMatcher.TargetId,
                    GameMatcher.Team));
        }

        public void Execute()
        {
            foreach (var bulletRequest in _bulletRequests)
            foreach (var bullet in _bullets.GetEntities(_buffer))
            {
                if (bulletRequest.BulletIndex == bullet.BulletIndex)
                {
                    _bulletFactory.CreateBullet(
                        bulletRequest.BulletTypeId,
                        bullet.TargetId,
                        bullet.BulletIndex,
                        bullet.Team);

                    bullet.isDestructed = true;
                }
            }
        }
    }
}
