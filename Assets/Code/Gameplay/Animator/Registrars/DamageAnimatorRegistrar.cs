using AbilityMadness.Code.Common.Behaviours;
using AbilityMadness.Code.Infrastructure.View;
using SF = UnityEngine.SerializeField;

namespace AbilityMadness.Code.Gameplay.Animator.Registrars
{
    [EntityTag("Registrars")]
    public class DamageAnimatorRegistrar : EntityComponentRegistrar
    {
        [SF] private DamageAnimator damageAnimator;

        public override void RegisterComponents(GameEntity entity)
        {
            entity.AddDamageAnimator(damageAnimator);
        }

        public override void UnregisterComponents(GameEntity entity)
        {
            if (entity.hasRigidbody2D)
                entity.RemoveRigidbody2D();
        }
    }
}
