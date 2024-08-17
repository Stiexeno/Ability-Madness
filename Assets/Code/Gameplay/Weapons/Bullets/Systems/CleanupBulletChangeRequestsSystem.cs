using Entitas;

namespace AbilityMadness.Code.Gameplay.Weapons.Bullets.Systems
{
    public class CleanupBulletChangeRequestsSystem : ICleanupSystem
    {
        private readonly IGroup<GameEntity> _bulletRequests;

        public CleanupBulletChangeRequestsSystem(GameContext gameContext)
        {
            _bulletRequests = gameContext.GetGroup(GameMatcher
                .AllOf(
                    GameMatcher.BulletChangeRequest));
        }

        public void Cleanup()
        {
            foreach (var bulletRequest in _bulletRequests)
            {
                bulletRequest.isDestructed = true;
            }
        }
    }
}
