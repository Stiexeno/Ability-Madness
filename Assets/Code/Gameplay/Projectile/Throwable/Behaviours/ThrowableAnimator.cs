using AbilityMadness.Code.Gameplay.Projectile.Systems.Throwable.Registrars;
using AbilityMadness.Code.Infrastructure.View;
using UnityEngine;
using SF = UnityEngine.SerializeField;

namespace AbilityMadness.Code.Gameplay.Projectile.Systems.Throwable.Behaviours
{
    [RequireComponent(typeof(ThrowableAnimatorRegistrar))]
    public class ThrowableAnimator : EntityComponent
    {
        [SF] private Transform sprite;
        [SF] private Transform shadow;

        [SF] private AnimationCurve heightCurve;

        public void SetHeight(float distance, float maxHeight)
        {
            sprite.transform.localPosition = Vector3.Lerp(Vector3.zero, Vector3.up * maxHeight, heightCurve.Evaluate(1f - distance));
            shadow.transform.localScale = Vector3.Lerp(Vector3.one, Vector3.one * 0.8f, heightCurve.Evaluate(1f - distance));
        }
    }
}
