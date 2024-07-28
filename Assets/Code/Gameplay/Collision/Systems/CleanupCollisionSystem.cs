using System.Collections.Generic;
using Entitas;

namespace AbilityMadness.Code.Gameplay.Collision.Systems
{
    public class CleanupCollisionSystem : IExecuteSystem
    {
        private List<GameEntity> _buffer = new(32);
        private IGroup<GameEntity> _collisions;

        public CleanupCollisionSystem(Contexts contexts)
        {
            _collisions = contexts.game.GetGroup(GameMatcher
                .AllOf(
                    GameMatcher.Collision));
        }

        public void Execute()
        {
            foreach (var collision in _collisions.GetEntities(_buffer))
            {
                collision.Destroy();
            }
        }
    }
}
