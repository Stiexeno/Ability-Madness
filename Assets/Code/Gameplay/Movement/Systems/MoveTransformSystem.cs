using Entitas;

namespace AbilityMadness.Code.Gameplay.Movement.Systems
{
    public class MoveTransformSystem : IExecuteSystem
    {
        private IGroup<GameEntity> _entities;

        public MoveTransformSystem(Contexts contexts)
        {
            _entities = contexts.game.GetGroup(GameMatcher
                .AllOf(
                    GameMatcher.WorldPosition,
                    GameMatcher.Transform,
                    GameMatcher.TransformMovement));
        }

        public void Execute()
        {
            foreach (var entity in _entities)
            {
                entity.Transform.position = entity.WorldPosition;
            }
        }
    }
}
