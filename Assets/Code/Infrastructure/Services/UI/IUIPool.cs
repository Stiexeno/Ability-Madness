using Cysharp.Threading.Tasks;
using UnityEngine;

namespace AbilityMadness.Code.Infrastructure.Services.UI
{
    public interface IUIPool
    {
        UniTask<T> Take<T>(string path, Transform parent) where T : MonoBehaviour;
        void Put<T>(T itemToPool) where T : MonoBehaviour;
    }
}
