using AbilityMadness.Code.Gameplay.Animator.Registrars;
using AbilityMadness.Code.Infrastructure.View;
using Animancer;
using UnityEngine;
using SF = UnityEngine.SerializeField;

namespace AbilityMadness.Code.Common.Behaviours
{
    [RequireComponent(typeof(DeathAnimatorRegistrar))]
    public class DeathAnimator : EntityComponent
    {
        [SF] private ClipTransition deathAnimation;
        [SF] private AnimancerComponent animancer;

        public void PlayDeath()
        {
            animancer.Play(deathAnimation);
        }

        public float GetDeathAnimationLength()
        {
            return deathAnimation.Clip.length;
        }
    }
}
