using AbilityMadness.Code.Common.Behaviours;
using SF = UnityEngine.SerializeField;

namespace AbilityMadness.Code.Gameplay.Animator.Registrars
{
    public class MovementAnimatorRegistrar : EntityComponentRegistrar
    {
        [SF] private Common.Behaviours.MovementAnimator movementAnimator;

        public override void RegisterComponents()
        {
            Entity
                .AddMovementAnimator(movementAnimator);
        }

        public override void UnregisterComponents()
        {
            if (Entity.hasRigidbody2D)
                Entity.RemoveRigidbody2D();
        }
    }
}
