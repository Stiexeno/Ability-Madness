using System.Collections.Generic;
using AbilityMadness.Code.Gameplay.Stats;
using AbilityMadness.Code.Gameplay.Stats.Factory;
using Entitas;

namespace AbilityMadness.Code.Gameplay.Status.Systems.Implementations
{
    public class ApplyFreezeStatusSystem : IExecuteSystem
    {
        private readonly List<GameEntity> _buffer = new(32);
        private IStatsFactory _statsFactory;
        private IGroup<GameEntity> _statuses;

        public ApplyFreezeStatusSystem(GameContext gameContext, IStatsFactory statsFactory)
        {
            _statsFactory = statsFactory;
            _statuses = gameContext.GetGroup(GameMatcher
                .AllOf(
                    GameMatcher.Id,
                    GameMatcher.Status,
                    GameMatcher.Freeze,
                    GameMatcher.ProducerId,
                    GameMatcher.TargetId,
                    GameMatcher.EffectValue)
                .NoneOf(
                    GameMatcher.Applied));
        }

        public void Execute()
        {
            foreach (var status in _statuses.GetEntities(_buffer))
            {
                _statsFactory.CreateStatsChange(
                    StatsTypeId.MovementSpeedMultiplier,
                    status.Id,
                    status.TargetId,
                    status.EffectValue);

                status.isApplied = true;
            }
        }
    }
}
