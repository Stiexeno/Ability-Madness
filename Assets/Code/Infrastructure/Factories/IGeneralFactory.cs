using Cysharp.Threading.Tasks;
using UnityEngine;

namespace AbilityMadness.Code.Infrastructure.Factories
{
    public interface IGeneralFactory
    {
        UniTask<T> Create<T>(string path) where T : MonoBehaviour;
    }
}
