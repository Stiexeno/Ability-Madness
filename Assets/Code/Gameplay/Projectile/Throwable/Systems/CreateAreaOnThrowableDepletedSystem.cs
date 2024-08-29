using AbilityMadness.Code.Gameplay.Area;
using AbilityMadness.Code.Gameplay.Area.Factory;
using Entitas;

namespace AbilityMadness.Code.Gameplay.Projectile.Systems.Implementations
{
    public class CreateAreaOnThrowableDepletedSystem : IExecuteSystem
    {
        private IAreaFactory _areaFactory;
        private IGroup<GameEntity> _throwables;

        public CreateAreaOnThrowableDepletedSystem(GameContext gameContext, IAreaFactory areaFactory)
        {
            _areaFactory = areaFactory;

            _throwables = gameContext.GetGroup(GameMatcher
                .AllOf(
                    GameMatcher.Throwable,
                    GameMatcher.Depleted));
        }

        public void Execute()
        {
            foreach (var throwable in _throwables)
            {
                _areaFactory.CreateArea(AreaTypeId.Poison, throwable.Id, throwable.WorldPosition, throwable.Team);
            }
        }
    }
}
