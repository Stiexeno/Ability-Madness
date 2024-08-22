using AbilityMadness.Code.Gameplay.Area.Factory;
using Entitas;

namespace AbilityMadness.Code.Gameplay.Trails.Systems
{
    public class CreateAreaWithTrailSystem : IExecuteSystem
    {
        private IGroup<GameEntity> _trails;
        private IAreaFactory _areaFactory;
        private IGroup<GameEntity> _producers;
        private GameContext _gameContext;

        public CreateAreaWithTrailSystem(GameContext gameContext, IAreaFactory areaFactory)
        {
            _gameContext = gameContext;
            _areaFactory = areaFactory;
            _trails = gameContext.GetGroup(GameMatcher
                .AllOf(
                    GameMatcher.Trail,
                    GameMatcher.Id,
                    GameMatcher.TrailTypeId,
                    GameMatcher.AreaTypeId,
                    GameMatcher.Ready,
                    GameMatcher.TargetId,
                    GameMatcher.DistanceTraveled));

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
                    _areaFactory.CreateArea(trail.AreaTypeId, trail.Id, producer.WorldPosition, producer.Team);
                    trail.DistanceTraveled = 0;
                }
            }
        }
    }
}
