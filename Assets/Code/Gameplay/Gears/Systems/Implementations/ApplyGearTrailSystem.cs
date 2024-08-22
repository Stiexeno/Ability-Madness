using AbilityMadness.Code.Gameplay.Trails.Factory;
using Entitas;

namespace AbilityMadness.Code.Gameplay.Gears.Systems.Implementations
{
    public class ApplyGearTrailSystem : IExecuteSystem
    {
        private IGroup<GameEntity> _gears;
        private ITrailFactory _trailFactory;

        public ApplyGearTrailSystem(GameContext gameContext, ITrailFactory trailFactory)
        {
            _trailFactory = trailFactory;
            _gears = gameContext.GetGroup(GameMatcher
                .AllOf(
                    GameMatcher.Gear,
                    GameMatcher.TrailTypeId,
                    GameMatcher.TargetId,
                    GameMatcher.NotApplied));
        }

        public void Execute()
        {
            foreach (var gear in _gears)
            {
                _trailFactory.CreateTrail(gear.TrailTypeId, gear.Id, gear.TargetId);
            }
        }
    }
}
