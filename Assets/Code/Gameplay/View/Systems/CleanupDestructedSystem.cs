using System.Collections.Generic;
using AbilityMadness.Code.Infrastructure.Services.View;
using Entitas;

namespace AbilityMadness.Code.Common.Systems
{
    public class CleanupDestructedSystem : IExecuteSystem
    {
        private List<GameEntity> _buffer = new(32);
        private IGroup<GameEntity> _entities;

        private IViewPool _viewPool;

        public CleanupDestructedSystem(Contexts contexts, IViewPool viewPool)
        {
            _viewPool = viewPool;

            _entities = contexts.game.GetGroup(GameMatcher
                .AllOf(GameMatcher.Destructed, GameMatcher.View));
        }

        public void Execute()
        {
            foreach (var entity in _entities.GetEntities(_buffer))
            {
                _viewPool.Put(entity.View);
                entity.RemoveView();
            }
        }
    }
}
