using System;
using AbilityMadness.Code.Gameplay.Animator.Registrars;
using AbilityMadness.Code.Infrastructure.View;
using Animancer;
using UnityEngine;
using SF = UnityEngine.SerializeField;

namespace AbilityMadness.Code.Common.Behaviours
{
    [RequireComponent(typeof(MovementAnimatorRegistrar))]
    public class MovementAnimator : EntityComponent
    {
        [SF] private LinearMixerTransition movementTransition;
        [SF] private AnimancerComponent animancer;
        [SF] private SpriteRenderer sprite;

        private Vector2 _velocity;

        private void OnEnable()
        {
            animancer.Play(movementTransition);
        }

        public void SetIdle(Vector2 lookDirection)
        {
            Flip(lookDirection);
            movementTransition.State.Parameter = 0;
        }

        public void SetWalk(Vector2 lookDirection)
        {
            Flip(lookDirection);
            movementTransition.State.Parameter = 1;
        }

        private void Flip(Vector2 lookDirection)
        {
            if (lookDirection.magnitude == 0f)
            {
                lookDirection = _velocity;
            }

            _velocity = lookDirection;
            sprite.flipX = lookDirection.x < 0 || lookDirection.x == 0 && sprite.flipX;
        }

        // private float GetLookParameter(Vector2 velocity)
        // {
        //     if (velocity.magnitude == 0f)
        //     {
        //         velocity = _velocity;
        //     }
        //
        //     _velocity = velocity;
        //
        //
        //     var parameter = 0f;
        //
        //     if (velocity.x > 0)
        //     {
        //         parameter = RIGHT_PARAMETER;
        //     }
        //     else if (velocity.x < 0)
        //     {
        //         parameter = LEFT_PARAMETER;
        //     }
        //     else if (velocity.y > 0)
        //     {
        //         parameter = BACK_PARAMETER;
        //     }
        //     else if (velocity.y < 0)
        //     {
        //         parameter = FRONT_PARAMETER;
        //     }
        //
        //     return parameter;
        // }

        // private float GetLookParameter(Vector2 lookDirection)
        // {
        //     if (lookDirection.magnitude == 0f)
        //     {
        //         lookDirection = _velocity;
        //     }
        //
        //     _velocity = lookDirection;
        //
        //     float angle = Mathf.Atan2(lookDirection.y, lookDirection.x) * Mathf.Rad2Deg;
        //     Quaternion rotation = Quaternion.AngleAxis(angle, Vector3.forward);
        //
        //     var rotationAngle = rotation.eulerAngles.z;
        //     var parameter = 0f;
        //
        //     if (rotationAngle >= 315 || rotationAngle <= 45)
        //     {
        //         parameter = RIGHT_PARAMETER;
        //     }
        //     else if (rotationAngle >= 135 && rotationAngle <= 225)
        //     {
        //         parameter = LEFT_PARAMETER;
        //     }
        //     else if (rotationAngle >= 45 && rotationAngle <= 135)
        //     {
        //         parameter = BACK_PARAMETER;
        //     }
        //     else if (rotationAngle >= 225 && rotationAngle <= 315)
        //     {
        //         parameter = FRONT_PARAMETER;
        //     }
        //
        //     return parameter;
        // }
    }
}
