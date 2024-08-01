using AbilityMadness.Code.Infrastructure.Services.View;
using Cysharp.Threading.Tasks;
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

        public void Execute()
        {
            foreach (var entity in _entities.GetEntities())
            {
                if (string.IsNullOrEmpty(entity.ViewPath))
                    continue;

                entity.isViewLoading = true;


                LoadView(entity).Forget();

            }
        }

        private async UniTaskVoid LoadView(GameEntity entity)
        {
            var entityView = await _viewPool.Take(entity.ViewPath);
            entityView.LinkEntity(entity);
            entityView.gameObject.SetActive(true);

            entity.AddView(entityView);
            entity.isViewLoading = false;
        }
    }
}
