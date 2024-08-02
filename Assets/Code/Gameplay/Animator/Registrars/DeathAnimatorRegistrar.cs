using AbilityMadness.Code.Common.Behaviours;
using AbilityMadness.Code.Infrastructure.View;
using SF = UnityEngine.SerializeField;

namespace AbilityMadness.Code.Gameplay.Animator.Registrars
{
    [EntityTag("Registrars")]
    public class DeathAnimatorRegistrar : EntityComponentRegistrar
    {
        [SF] private DeathAnimator deathAnimator;

        public override void RegisterComponents(GameEntity entity)
        {
            entity.AddDeathAnimator(deathAnimator);
        }

        public override void UnregisterComponents(GameEntity entity)
        {
            entity.RemoveDeathAnimator();
        }
    }
}
