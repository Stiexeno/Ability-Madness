using AbilityMadness.Code.Infrastructure.View;
using Cysharp.Threading.Tasks;

namespace AbilityMadness.Code.Infrastructure.Services.View
{
    public interface IViewPool
    {
        UniTask<EntityView> Take(string path);
        void Put(EntityView entityView);
    }
}
