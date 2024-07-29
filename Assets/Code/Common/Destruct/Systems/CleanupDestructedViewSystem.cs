using System.Collections.Generic;
using AbilityMadness.Code.Infrastructure.Services.View;
using Entitas;

namespace AbilityMadness.Code.Common.Destruct.Systems
{
    public class CleanupDestructedViewSystem : ICleanupSystem
    {
        private List<GameEntity> _buffer = new(32);
        private IGroup<GameEntity> _entities;

        private IViewPool _viewPool;

        public CleanupDestructedViewSystem(Contexts contexts, IViewPool viewPool)
        {
            _viewPool = viewPool;

            _entities = contexts.game.GetGroup(GameMatcher
                .AllOf(GameMatcher.Destructed, GameMatcher.View));
        }

        public void Cleanup()
        {
            foreach (var entity in _entities.GetEntities(_buffer))
            {
                _viewPool.Put(entity.View);
                entity.RemoveView();
            }
        }
    }
}
