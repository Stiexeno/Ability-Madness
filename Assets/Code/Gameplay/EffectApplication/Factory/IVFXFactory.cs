using Cysharp.Threading.Tasks;
using UnityEngine;

namespace AbilityMadness.Code.Gameplay.EffectApplication.Factory
{
    public interface IVFXFactory
    {
        UniTaskVoid CreateVFX(string path, Vector3 position);
    }
}
