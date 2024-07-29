using AbilityMadness.Code.Infrastructure.View;
using SF = UnityEngine.SerializeField;

namespace AbilityMadness.Code.Gameplay.Animator.Registrars
{
    public class MovementAnimatorRegistrar : EntityComponentRegistrar
    {
        [SF] private Common.Behaviours.MovementAnimator movementAnimator;

        public override void RegisterComponents(GameEntity entity)
        {
            entity.AddMovementAnimator(movementAnimator);
        }

        public override void UnregisterComponents(GameEntity entity)
        {
            if (entity.hasRigidbody2D)
                entity.RemoveRigidbody2D();
        }
    }
}
