using Entitas;

namespace AbilityMadness.Code.Gameplay.Stats.Systems
{
    public class ApplyStatsModifiersSystem : IExecuteSystem
    {
        private IGroup<GameEntity> _statOwners;
        private IGroup<GameEntity> _statsChanges;
        private GameContext _gameContext;

        public ApplyStatsModifiersSystem(GameContext gameContext)
        {
            _gameContext = gameContext;

            _statOwners = gameContext.GetGroup(GameMatcher
                .AllOf(
                    GameMatcher.StatsModifiers,
                    GameMatcher.Id));

            _statsChanges = gameContext.GetGroup(GameMatcher
                .AllOf(
                    GameMatcher.StatsChange,
                    GameMatcher.StatsValue,
                    GameMatcher.TargetId));
        }

        public void Execute()
        {
            foreach (var statChange in _statsChanges)
            {
                var owner = _gameContext.GetEntityWithId(statChange.TargetId);

                if (_statOwners.ContainsEntity(owner))
                {
                    owner.StatsModifiers.stats[statChange.StatsChange] += statChange.StatsValue;
                }
            }
        }
    }
}
