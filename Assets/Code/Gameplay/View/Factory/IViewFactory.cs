using Cysharp.Threading.Tasks;
using UnityEngine.AddressableAssets;

namespace AbilityMadness.Code.Common.Factory
{
    public interface IViewFactory
    {
        UniTask<GameEntity> CreateView(GameEntity entity, string path);
        UniTask<GameEntity> CreateView(GameEntity entity,  AssetReferenceGameObject assetRef);
    }
}
