using Entitas;
using UnityEngine;

namespace AbilityMadness.Code.Gameplay.Stats.Systems
{
    public class MaxHealthStatsSystem : IExecuteSystem
    {
        private IGroup<GameEntity> _statOwners;

        public MaxHealthStatsSystem(GameContext gameContext)
        {
            _statOwners = gameContext.GetGroup(GameMatcher
                .AllOf(
                    GameMatcher.BaseStats,
                    GameMatcher.StatsModifiers,
                    GameMatcher.MaxHealth));
        }

        public void Execute()
        {
            foreach (var statOwner in _statOwners)
            {
                statOwner.MaxHealth = Mathf.RoundToInt(statOwner.StatsModifiers.stats[StatsTypeId.MaxHealth] +
                                                       statOwner.BaseStats.stats[StatsTypeId.MaxHealth]);
            }
        }
    }
}
