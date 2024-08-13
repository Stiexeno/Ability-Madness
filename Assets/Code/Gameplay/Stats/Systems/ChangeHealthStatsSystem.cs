using Entitas;
using UnityEngine;

namespace AbilityMadness.Code.Gameplay.Stats.Systems
{
    public class ChangeHealthStatsSystem : IExecuteSystem
    {
        private IGroup<GameEntity> _stats;
        private IGroup<GameEntity> _targets;
        private GameContext _gameContext;

        public ChangeHealthStatsSystem(GameContext gameContext)
        {
            _gameContext = gameContext;
            _stats = gameContext.GetGroup(GameMatcher
                .AllOf(
                    GameMatcher.StatsChange,
                    GameMatcher.TargetId,
                    GameMatcher.StatsValue));

            _targets = gameContext.GetGroup(GameMatcher
                .AllOf(
                    GameMatcher.Id,
                    GameMatcher.Health,
                    GameMatcher.MaxHealth));
        }

        public void Execute()
        {
            foreach (var stat in _stats)
            {
                if (stat.StatsChange == StatsTypeId.Health)
                {
                    var target =_gameContext.GetEntityWithId(stat.TargetId);

                    if (_targets.ContainsEntity(target))
                    {
                        target.Health += Mathf.RoundToInt(stat.StatsValue);
                    }
                }
            }
        }
    }
}
