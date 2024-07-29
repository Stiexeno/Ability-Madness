using Entitas;

namespace AbilityMadness.Code.Gameplay.Input.Systems
{
    public class RemoveMouseHoverSystem : IExecuteSystem
    {
        private IGroup<GameEntity> _mouseCollisions;
        private Contexts _contexts;

        public RemoveMouseHoverSystem(Contexts contexts)
        {
            _contexts = contexts;

            _mouseCollisions = contexts.game.GetGroup(GameMatcher
                .AllOf(
                    GameMatcher.MouseCollision,
                    GameMatcher.CollisionExit,
                    GameMatcher.CollidedId));
        }
        public void Execute()
        {
            foreach (var mouseCollision in _mouseCollisions)
            {
                var collidedEntity = _contexts.game.GetEntityWithId(mouseCollision.CollidedId);

                if (collidedEntity == null)
                    continue;

                collidedEntity.isMouseInHover = false;
            }
        }
    }
}
