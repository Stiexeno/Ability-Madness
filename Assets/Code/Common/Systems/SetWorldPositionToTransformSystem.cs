using Entitas;

namespace AbilityMadness.Code.Common.Systems
{
    public class SetWorldPositionToTransformSystem : IExecuteSystem
    {
        private IGroup<GameEntity> _entities;

        public SetWorldPositionToTransformSystem(Contexts contexts)
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
