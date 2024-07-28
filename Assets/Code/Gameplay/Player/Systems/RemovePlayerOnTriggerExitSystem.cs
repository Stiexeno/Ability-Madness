using Entitas;

namespace AbilityMadness.Systems
{
    public class RemovePlayerOnTriggerExitSystem : IExecuteSystem
    {
        private IGroup<GameEntity> _collisions;
        private IGroup<GameEntity> _players;
        private Contexts _contexts;

        public RemovePlayerOnTriggerExitSystem(Contexts contexts)
        {
            _contexts = contexts;
            _collisions = contexts.game.GetGroup(GameMatcher
                .AllOf(
                    GameMatcher.TriggerExit,
                    GameMatcher.CollidedId,
                    GameMatcher.ColliderOwnerId));

            _players = contexts.game.GetGroup(GameMatcher
                .AllOf(
                    GameMatcher.Id,
                    GameMatcher.Player,
                    GameMatcher.WorldPosition));
        }

        public void Execute()
        {
            foreach (var collision in _collisions)
            {
                var player = _contexts.game.GetEntityWithId(collision.ColliderOwnerId);
                var colliderOwner = _contexts.game.GetEntityWithId(collision.CollidedId);

                if (colliderOwner == null || !_players.ContainsEntity(player))
                    continue;

                colliderOwner.isPlayerTriggered = false;
            }
        }
    }
}
