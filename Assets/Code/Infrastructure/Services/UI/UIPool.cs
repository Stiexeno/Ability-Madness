using System.Collections.Generic;
using AbilityMadness.Code.Infrastructure.Factories;
using AbilityMadness.Infrastructure.Services.Assets;
using Cysharp.Threading.Tasks;
using UnityEngine;

namespace AbilityMadness.Code.Infrastructure.Services.UI
{
    public class UIPool : IUIPool
    {
        private Dictionary<string, List<MonoBehaviour>> _pooledViews = new();

        private GeneralFactory _generalFactory;

        public UIPool(IAssets assets)
        {
            _generalFactory = new GeneralFactory(assets);
        }

        public async UniTask<T> Take<T>(string path, Transform parent) where T : MonoBehaviour
        {
            if (_pooledViews.TryGetValue(path, out List<MonoBehaviour> entityViews))
            {
                if (entityViews != null && entityViews.Count > 0)
                {
                    foreach (var view in entityViews)
                    {
                        if (view.gameObject.activeSelf == false)
                        {
                            view.transform.SetParent(parent);
                            return view as T;
                        }
                    }
                }
            }

            return await Create<T>(path, parent);
        }

        public void Put<T>(T itemToPool) where T : MonoBehaviour
        {
            itemToPool.gameObject.SetActive(false);
        }

        private async UniTask<T> Create<T>(string path, Transform parent) where T : MonoBehaviour
        {
            var viewInstance = await _generalFactory.Create<T>(path);

            if (_pooledViews.ContainsKey(path) == false)
            {
                _pooledViews.Add(path, new List<MonoBehaviour>());
            }

            _pooledViews[path].Add(viewInstance);

            viewInstance.transform.SetParent(parent);

            return viewInstance;
        }
    }
}
