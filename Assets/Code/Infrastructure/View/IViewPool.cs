using Cysharp.Threading.Tasks;
using UnityEngine.AddressableAssets;

namespace AbilityMadness.Code.Infrastructure.View
{
    public interface IViewPool
    {
        UniTask<EntityView> Take(string path);
        void Put(EntityView entityView);
        UniTask<EntityView> Take(AssetReferenceGameObject assetRef);
    }
}
