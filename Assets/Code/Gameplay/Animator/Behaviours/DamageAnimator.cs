using AbilityMadness.Code.Gameplay.Animator.Registrars;
using AbilityMadness.Code.Infrastructure.View;
using DG.Tweening;
using UnityEngine;
using SF = UnityEngine.SerializeField;

namespace AbilityMadness.Code.Common.Behaviours
{
    [RequireComponent(typeof(DamageAnimatorRegistrar))]
    public class DamageAnimator : EntityComponent
    {
        [SF] private UnityEngine.Transform sprite;

        public void PlayDamageAnimation()
        {
            sprite.transform.DOKill(true);
            sprite.transform.DOPunchScale(Vector3.one * 0.25f, 0.15f, 10, 1);
        }
    }
}
