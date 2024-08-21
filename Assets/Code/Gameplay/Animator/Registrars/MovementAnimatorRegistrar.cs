using AbilityMadness.Code.Common.Behaviours;
using AbilityMadness.Code.Infrastructure.View;
using SF = UnityEngine.SerializeField;

namespace AbilityMadness.Code.Gameplay.Animator.Registrars
{
    [EntityTag("Registrars")]
    public class MovementAnimatorRegistrar : EntityComponentRegistrar
    {
        [SF] private MovementAnimator movementAnimator;

        public override void RegisterComponents(GameEntity entity)
        {
            entity.AddMovementAnimator(movementAnimator);
        }

        public override void UnregisterComponents(GameEntity entity)
        {
            if (entity.hasMovementAnimator)
                entity.RemoveMovementAnimator();
        }
    }
}
