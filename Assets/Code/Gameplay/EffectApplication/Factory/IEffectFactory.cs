using Cysharp.Threading.Tasks;
using UnityEngine;

namespace AbilityMadness.Code.Gameplay.EffectApplication.Factory
{
    public interface IEffectFactory
    {
        UniTaskVoid CreateEffect(string path, Vector3 position);
    }
}
