using AbilityMadness.Code.Gameplay.Weapons.Bullets.Services;
using Entitas;

namespace AbilityMadness.Code.Gameplay.Weapons.Bullets.Systems
{
    public class SendBulletEntitiesToServiceSystem : IExecuteSystem
    {
        private IBulletService _bulletService;
        private IGroup<GameEntity> _bullets;

        public SendBulletEntitiesToServiceSystem(GameContext gameContext, IBulletService bulletService)
        {
            _bulletService = bulletService;
            _bullets = gameContext.GetGroup(GameMatcher
                .AllOf(
                    GameMatcher.Bullet,
                    GameMatcher.BulletIndex));
        }

        public void Execute()
        {
            foreach (var bullet in _bullets)
            {
                if (_bulletService.Bullets.Count - 1 < bullet.BulletIndex)
                {
                    _bulletService.Bullets.Add(bullet.BulletTypeId);
                }

                _bulletService.Bullets[bullet.BulletIndex] = bullet.BulletTypeId;
            }
        }
    }
}
