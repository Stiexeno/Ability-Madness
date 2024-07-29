using Entitas;

namespace AbilityMadness.Code.Gameplay.Input.Systems
{
    public class MarkMouseHoverSystem : IExecuteSystem
    {
        private IGroup<GameEntity> _mouseCollisions;
        private Contexts _contexts;

        public MarkMouseHoverSystem(Contexts contexts)
        {
            _contexts = contexts;

            _mouseCollisions = contexts.game.GetGroup(GameMatcher
                .AllOf(
                    GameMatcher.MouseCollision,
                    GameMatcher.CollisionEnter,
                    GameMatcher.CollidedId));
        }
        public void Execute()
        {
            foreach (var mouseCollision in _mouseCollisions)
            {
                var collidedEntity = _contexts.game.GetEntityWithId(mouseCollision.CollidedId);

                if (collidedEntity == null)
                    continue;

                collidedEntity.isMouseInHover = true;
            }
        }
    }
}
