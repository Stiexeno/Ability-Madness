using Entitas;

namespace AbilityMadness.Code.Gameplay.Movement.Systems
{
    public class IncreaseDistanceTraveledSystem : IExecuteSystem
    {
        private IGroup<GameEntity> _movers;

        public IncreaseDistanceTraveledSystem(GameContext gameContext)
        {
            _movers = gameContext.GetGroup(GameMatcher
                .AllOf(
                    GameMatcher.DistanceTraveled,
                    GameMatcher.LastPosition,
                    GameMatcher.WorldPosition));
        }

        public void Execute()
        {
            foreach (var mover in _movers)
            {
                var distance = (mover.WorldPosition - mover.LastPosition).magnitude;
                mover.DistanceTraveled += distance;

                mover.LastPosition = mover.WorldPosition;
            }
        }
    }
}
