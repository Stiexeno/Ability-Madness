using AbilityMadness.Code.Gameplay.Animator.Registrars;
using Animancer;
using UnityEngine;
using SF = UnityEngine.SerializeField;

namespace AbilityMadness.Code.Common.Behaviours
{
    [RequireComponent(typeof(MovementAnimatorRegistrar))]
    public class MovementAnimator : EntityComponent
    {
        [SF] private LinearMixerTransition movementTransition;


    }
}
