using AbilityMadness.Code.Infrastructure.View;
using Cysharp.Threading.Tasks;
using UnityEngine.AddressableAssets;

namespace AbilityMadness.Code.Common.Factory
{
    public class ViewFactory : IViewFactory
    {
        private IViewPool _viewPool;

        public ViewFactory(IViewPool viewPool)
        {
            _viewPool = viewPool;
        }

        public async UniTask<GameEntity> CreateView(GameEntity entity, string path)
        {
            var entityView = await _viewPool.Take(path);
            entityView.LinkEntity(entity);

            if (entity.hasWorldPosition)
            {
                entityView.transform.position = entity.WorldPosition;
            }

            entityView.gameObject.SetActive(true);

            entity.AddView(entityView);
            entity.isLoading = false;

            return entity;
        }

        public async UniTask<GameEntity> CreateView(GameEntity entity,  AssetReferenceGameObject assetRef)
        {
            var entityView = await _viewPool.Take(assetRef);
            entityView.LinkEntity(entity);

            if (entity.hasWorldPosition)
            {
                entityView.transform.position = entity.WorldPosition;
            }

            entityView.gameObject.SetActive(true);

            entity.AddView(entityView);
            entity.isLoading = false;

            return entity;
        }
    }
}
