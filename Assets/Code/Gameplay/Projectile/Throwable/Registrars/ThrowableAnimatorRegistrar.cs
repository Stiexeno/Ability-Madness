using AbilityMadness.Code.Gameplay.Projectile.Systems.Throwable.Behaviours;
using AbilityMadness.Code.Infrastructure.View;
using SF = UnityEngine.SerializeField;

namespace AbilityMadness.Code.Gameplay.Projectile.Systems.Throwable.Registrars
{
    [EntityTag("Registrars")]
    public class ThrowableAnimatorRegistrar : EntityComponentRegistrar
    {
        [SF] private ThrowableAnimator throwableAnimator;

        public override void RegisterComponents(GameEntity entity)
        {
            entity.AddThrowableAnimator(throwableAnimator);
        }

        public override void UnregisterComponents(GameEntity entity)
        {
            entity.RemoveThrowableAnimator();
        }
    }
}
