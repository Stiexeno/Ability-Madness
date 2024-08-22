using System.Collections.Generic;
using Entitas;

namespace AbilityMadness.Code.Gameplay.Gears.Systems
{
    public class MarkGearAppliedSystem : IExecuteSystem
    {
        private readonly List<GameEntity> _buffer = new(32);
        private IGroup<GameEntity> _gears;

        public MarkGearAppliedSystem(GameContext gameContext)
        {
            _gears = gameContext.GetGroup(GameMatcher
                .AllOf(
                    GameMatcher.Gear,
                    GameMatcher.NotApplied));
        }

        public void Execute()
        {
            foreach (var gear in _gears.GetEntities(_buffer))
            {
                gear.isNotApplied = false;
            }
        }
    }
}
