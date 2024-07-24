using AbilityMadness.Code.Infrastructure.Services.View;
using Entitas;

namespace AbilityMadness.Code.Common.Systems
{
    public class BindEntityViewFromPathSystem : IExecuteSystem
    {
        private IGroup<GameEntity> _entities;

        private IViewPool _viewPool;

        public BindEntityViewFromPathSystem(Contexts contexts, IViewPool viewPool)
        {
            _viewPool = viewPool;

            _entities = contexts.game.GetGroup(GameMatcher
                .AllOf(GameMatcher.ViewPath)
                .NoneOf(GameMatcher.ViewLoading, GameMatcher.View));
        }

        public async void Execute()
        {
            foreach (var entity in _entities.GetEntities())
            {
                if (string.IsNullOrEmpty(entity.ViewPath))
                    continue;

                entity.isViewLoading = true;

                var entityView = await _viewPool.Take(entity.ViewPath);
                entityView.gameObject.SetActive(true);

                entity.AddView(entityView);
                entity.isViewLoading = false;
            }
        }
    }
}
