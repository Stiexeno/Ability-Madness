using Entitas;

namespace AbilityMadness.Code.Gameplay.Status.Systems
{
    public class CleanupDepletedStatsChangesSystem : IExecuteSystem
    {
        private IGroup<GameEntity> _statuses;
        private IGroup<GameEntity> _statsChanges;
        private GameContext _gameContext;

        public CleanupDepletedStatsChangesSystem(GameContext gameContext)
        {
            _gameContext = gameContext;
            _statuses = gameContext.GetGroup(GameMatcher
                .AllOf(
                    GameMatcher.Status,
                    GameMatcher.Depleted,
                    GameMatcher.ProducerId));

            _statsChanges = gameContext.GetGroup(GameMatcher
                .AllOf(
                    GameMatcher.StatsChange,
                    GameMatcher.ProducerId));
        }

        public void Execute()
        {
            foreach (var statChange in _statsChanges)
            {
                var producer = _gameContext.GetEntityWithId(statChange.ProducerId);

                if (_statuses.ContainsEntity(producer))
                {
                    statChange.isDestructed = true;
                }
            }
        }
    }
}
