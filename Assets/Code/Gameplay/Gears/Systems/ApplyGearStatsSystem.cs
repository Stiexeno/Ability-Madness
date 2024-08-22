using System.Collections.Generic;
using AbilityMadness.Code.Gameplay.Stats.Factory;
using Entitas;

namespace AbilityMadness.Code.Gameplay.Gears.Systems
{
    public class ApplyGearStatsSystem : IExecuteSystem
    {
        private readonly List<GameEntity> _buffer = new(32);
        private IGroup<GameEntity> _gears;
        private IStatsFactory _statsFactory;

        public ApplyGearStatsSystem(GameContext gameContext, IStatsFactory statsFactory)
        {
            _statsFactory = statsFactory;
            _gears = gameContext.GetGroup(GameMatcher
                .AllOf(
                    GameMatcher.Gear,
                    GameMatcher.TargetId,
                    GameMatcher.StatsSetups,
                    GameMatcher.NotApplied));
        }

        public void Execute()
        {
            foreach (var gear in _gears.GetEntities(_buffer))
            {
                foreach (var statsSetup in gear.StatsSetups)
                {
                    _statsFactory.CreateStatsChange(statsSetup.type, gear.Id, gear.TargetId, statsSetup.value);
                }

                gear.isNotApplied = false;
            }
        }
    }
}
