using Entitas;

namespace AbilityMadness.Code.Gameplay.Movement.Systems
{
    public class SetWorldPositionByTransformSystem : IExecuteSystem
    {
        private IGroup<GameEntity> _entities;

        public SetWorldPositionByTransformSystem(Contexts contexts)
        {
            _entities = contexts.game.GetGroup(GameMatcher
                .AllOf(
                    GameMatcher.WorldPosition,
                    GameMatcher.Transform,
                    GameMatcher.Alive)
                .NoneOf(GameMatcher.TransformMovement));
        }

        public void Execute()
        {
            foreach (var entity in _entities)
            {
                entity.WorldPosition = entity.Transform.position;
            }
        }
    }
}
