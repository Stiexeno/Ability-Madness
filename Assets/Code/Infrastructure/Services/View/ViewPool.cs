using System.Collections.Generic;
using AbilityMadness.Code.Infrastructure.Factories;
using AbilityMadness.Code.Infrastructure.View;
using AbilityMadness.Infrastructure.Services.Assets;
using Cysharp.Threading.Tasks;

namespace AbilityMadness.Code.Infrastructure.Services.View
{
    public class ViewPool : IViewPool
    {
        private Dictionary<string, List<EntityView>> _pooledViews = new();

        private GeneralFactory _generalFactory;

        public ViewPool(IAssets assets)
        {
            _generalFactory = new GeneralFactory(assets);
        }

        public async UniTask<EntityView> Take(string path)
        {
            if (_pooledViews.TryGetValue(path, out List<EntityView> entityViews))
            {
                if (entityViews != null && entityViews.Count > 0)
                {
                    foreach (var view in entityViews)
                    {
                        if (view.gameObject.activeSelf == false)
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

            return viewInstance;
        }
    }
}
