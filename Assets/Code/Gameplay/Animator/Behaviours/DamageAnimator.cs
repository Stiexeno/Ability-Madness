using AbilityMadness.Code.Gameplay.Animator.Registrars;
using AbilityMadness.Code.Infrastructure.View;
using DG.Tweening;
using UnityEngine;

namespace AbilityMadness.Code.Common.Behaviours
{
    [RequireComponent(typeof(DamageAnimatorRegistrar))]
    public class DamageAnimator : EntityComponent
    {
        public void PlayDamageAnimation()
        {
            transform.DOKill(true);
            transform.DOPunchScale(Vector3.one * 0.1f, 0.1f, 10, 1);
        }
    }
}
