using System;
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
        [SF] private AnimancerComponent animancer;

        private const float BACK_PARAMETER = 0;
        private const float RIGHT_PARAMETER = 1;
        private const float FRONT_PARAMETER = 2;
        private const float LEFT_PARAMETER = 3;

        private void OnEnable()
        {
            animancer.Play(movementTransition);
        }

        public void SetIdle(Vector2 lookDirection)
        {
            var parameter = GetLookParameter(lookDirection);
            movementTransition.State.Parameter = parameter;
        }

        public void SetWalk(Vector2 lookDirection)
        {
            var parameter = GetLookParameter(lookDirection);
            parameter += 4;

            movementTransition.State.Parameter = Mathf.RoundToInt(parameter);
        }

        private float GetLookParameter(Vector2 lookDirection)
        {
            float angle = Mathf.Atan2(lookDirection.y, lookDirection.x) * Mathf.Rad2Deg;
            Quaternion rotation = Quaternion.AngleAxis(angle, Vector3.forward);

            var rotationAngle = rotation.eulerAngles.z;
            var parameter = 0f;

            if (rotationAngle >= 315 || rotationAngle <= 45)
            {
                parameter = RIGHT_PARAMETER;
            }
            else if (rotationAngle >= 45 && rotationAngle <= 135)
            {
                parameter = BACK_PARAMETER;
            }
            else if (rotationAngle >= 225 && rotationAngle <= 315)
            {
                parameter = FRONT_PARAMETER;
            }
            else if (rotationAngle >= 135 && rotationAngle <= 225)
            {
                parameter = LEFT_PARAMETER;
            }

            return parameter;
        }
    }
}
