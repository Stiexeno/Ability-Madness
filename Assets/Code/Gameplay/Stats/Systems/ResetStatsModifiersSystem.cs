using Entitas;

namespace AbilityMadness.Code.Gameplay.Stats.Systems
{
    public class ResetStatsModifiersSystem : IExecuteSystem
    {
        private IGroup<GameEntity> _statOwners;
        private IGroup<GameEntity> _statsChanges;

        public ResetStatsModifiersSystem(GameContext gameContext)
        {
            _statOwners = gameContext.GetGroup(GameMatcher
                .AllOf(
                    GameMatcher.StatsModifiers));
        }

        public void Execute()
        {
            foreach (var statOwner in _statOwners)
            {
                statOwner.StatsModifiers.Reset();
            }
        }
    }
}
