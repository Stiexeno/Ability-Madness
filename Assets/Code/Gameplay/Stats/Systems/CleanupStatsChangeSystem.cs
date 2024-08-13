using Entitas;

namespace AbilityMadness.Code.Gameplay.Stats.Systems
{
    public class CleanupStatsChangeSystem : ICleanupSystem
    {
        private IGroup<GameEntity> _stats;

        public CleanupStatsChangeSystem(GameContext gameContext)
        {
            _stats = gameContext.GetGroup(GameMatcher
                .AllOf(
                    GameMatcher.StatsChange));
        }

        public void Cleanup()
        {
            foreach (var stat in _stats)
            {
                stat.isDestructed = true;
            }
        }
    }
}
