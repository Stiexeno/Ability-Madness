using System.Collections.Generic;
using Entitas;

namespace AbilityMadness.Code.Gameplay
{
    public class CleanupDestructedSystem : IExecuteSystem
    {
        private List<GameEntity> _buffer = new(32);
        private IGroup<GameEntity> _entities;

        public CleanupDestructedSystem(Contexts contexts)
        {
            _entities = contexts.game.GetGroup(GameMatcher
                .AllOf(GameMatcher.Destructed));
        }

        public void Execute()
        {
            foreach (var entity in _entities.GetEntities(_buffer))
            {
                entity.Destroy();
            }
        }
    }
}
