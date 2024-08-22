using Entitas;

namespace AbilityMadness.Code.Gameplay.Trails.Systems
{
    public class MarkTrailReadyOnDistanceTraveledSystem : IExecuteSystem
    {
        private IGroup<GameEntity> _trails;
        private IGroup<GameEntity> _producers;
        private GameContext _gameContext;

        public MarkTrailReadyOnDistanceTraveledSystem(GameContext gameContext)
        {
            _gameContext = gameContext;
            _trails = gameContext.GetGroup(GameMatcher
                .AllOf(
                    GameMatcher.Trail,
                    GameMatcher.DistanceTraveled,
                    GameMatcher.DistanceThreshold,
                    GameMatcher.LastPosition,
                    GameMatcher.TargetId));

            _producers = gameContext.GetGroup(GameMatcher
                .AllOf(
                    GameMatcher.Id,
                    GameMatcher.WorldPosition));
        }

        public void Execute()
        {
            foreach (var trail in _trails)
            {
                var producer = _gameContext.GetEntityWithId(trail.TargetId);

                if (_producers.ContainsEntity(producer))
                {
                    trail.isReady = trail.DistanceTraveled >= trail.DistanceThreshold;

                    var distance = (trail.LastPosition - producer.WorldPosition).magnitude;
                    trail.DistanceTraveled += distance;
                    trail.LastPosition = producer.WorldPosition;
                }
            }
        }
    }
}
