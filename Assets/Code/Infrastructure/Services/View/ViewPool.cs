using System.Collections.Generic;
using AbilityMadness.Code.Infrastructure.Factories;
using AbilityMadness.Code.Infrastructure.View;
using AbilityMadness.Infrastructure.Services.Assets;
using Cysharp.Threading.Tasks;
using UnityEngine;
using UnityEngine.AddressableAssets;

namespace AbilityMadness.Code.Infrastructure.Services.View
{
    public class ViewPool : IViewPool
    {
        private Dictionary<string, List<EntityView>> _pooledViews = new();
        private Transform _viewsParent;

        private GeneralFactory _generalFactory;
        private IAssets _assets;

        public ViewPool(IAssets assets)
        {
            _assets = assets;
            _generalFactory = new GeneralFactory(assets);
            _viewsParent = new GameObject("View").transform;
        }

        public async UniTask<EntityView> Take(AssetReferenceGameObject assetRef)
        {
            var loaded = await _assets.LoadAsync<GameObject>(assetRef);
            var key = loaded.gameObject.GetInstanceID().ToString();

            if (_pooledViews.TryGetValue(key, out List<EntityView> entityViews))
            {
                if (entityViews != null && entityViews.Count > 0)
                {
                    foreach (var view in entityViews)
                    {
                        if (view.gameObject.activeSelf == false && view.Entity == null)
                        {
                            return view;
                        }
                    }
                }
            }

            var createdItem = _assets.Instantiate<EntityView>(loaded);

            if (_pooledViews.TryGetValue(key, out entityViews))
            {
                entityViews.Add(createdItem);
                return createdItem;
            }

            _pooledViews.Add(key, new List<EntityView> { createdItem });

            return createdItem;
        }

        public async UniTask<EntityView> Take(string path)
        {
            if (_pooledViews.TryGetValue(path, out List<EntityView> entityViews))
            {
                if (entityViews != null && entityViews.Count > 0)
                {
                    foreach (var view in entityViews)
                    {
                        if (view.gameObject.activeSelf == false && view.Entity == null)
                        {
                            return view;
                        }
                    }
                }
            }

            return await Create(path);
        }

        public void Put(EntityView entityView)
        {
            entityView.ReleaseEntity();
            entityView.gameObject.SetActive(false);
        }

        private async UniTask<EntityView> Create(string path)
        {
            var viewInstance = await _generalFactory.Create<EntityView>(path);

            if (_pooledViews.ContainsKey(path) == false)
            {
                _pooledViews.Add(path, new List<EntityView>());
            }

            _pooledViews[path].Add(viewInstance);

            viewInstance.gameObject.SetActive(false);
            viewInstance.transform.SetParent(_viewsParent);

            return viewInstance;
        }
    }
}
