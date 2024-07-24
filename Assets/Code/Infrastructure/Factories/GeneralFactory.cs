using AbilityMadness.Infrastructure.Services.Assets;
using Cysharp.Threading.Tasks;
using UnityEngine;

namespace AbilityMadness.Code.Infrastructure.Factories
{
    public class GeneralFactory : IGeneralFactory
    {
        private IAssets assets;

        public GeneralFactory(IAssets assets)
        {
            this.assets = assets;
        }

        public async UniTask<T> Create<T>(string path) where T : MonoBehaviour
        {
            var prefabGameObject = await assets.LoadAsync<GameObject>(path);

            if (prefabGameObject == null)
            {
                Debug.LogError($"{nameof(GeneralFactory)}: Prefab by path {path} not found");
                return null;
            }

            return assets.Instantiate<T>(prefabGameObject);
        }
    }
}
