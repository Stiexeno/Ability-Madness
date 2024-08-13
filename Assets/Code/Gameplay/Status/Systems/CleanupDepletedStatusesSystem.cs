using Entitas;

namespace AbilityMadness.Code.Gameplay.Status.Systems
{
    public class CleanupDepletedStatusesSystem : ICleanupSystem
    {
        private IGroup<GameEntity> _statuses;

        public CleanupDepletedStatusesSystem(GameContext gameContext)
        {
            _statuses = gameContext.GetGroup(GameMatcher
                .AllOf(
                    GameMatcher.Status,
                    GameMatcher.Depleted));
        }

        public void Cleanup()
        {
            foreach (var status in _statuses)
            {
                status.isDestructed = true;
            }
        }
    }
}
