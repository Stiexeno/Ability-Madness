using Entitas;
using UnityEngine;

namespace AbilityMadness.Code.Gameplay.Stats.Systems
{
    public class MovementSpeedStatsSystem : IExecuteSystem
    {
        private IGroup<GameEntity> _statOwners;

        public MovementSpeedStatsSystem(GameContext gameContext)
        {
            _statOwners = gameContext.GetGroup(GameMatcher
                .AllOf(
                    GameMatcher.BaseStats,
                    GameMatcher.StatsModifiers,
                    GameMatcher.MovementSpeed));
        }

        public void Execute()
        {
            foreach (var statOwner in _statOwners)
            {
                var movementSpeed = statOwner.BaseStats.stats[StatsTypeId.MovementSpeed] +
                                    statOwner.StatsModifiers.stats[StatsTypeId.MovementSpeed];

                movementSpeed *= statOwner.StatsModifiers.stats[StatsTypeId.MovementSpeedMultiplier];

                statOwner.MovementSpeed = Mathf.Max(movementSpeed, 0f);
            }
        }
    }
}
