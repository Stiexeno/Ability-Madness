using AbilityMadness.Code.Gameplay.Weapons.Behaviours;
using AbilityMadness.Code.Infrastructure.View;
using SF = UnityEngine.SerializeField;

namespace AbilityMadness.Code.Gameplay.Weapons.Registrars
{
    [EntityTag("Registrars")]
    public class WeaponAnimatorRegistrar : EntityComponentRegistrar
    {
        [SF] private WeaponAnimator weaponAnimator;

        public override void RegisterComponents(GameEntity entity)
        {
            entity.AddWeaponAnimator(weaponAnimator);
        }

        public override void UnregisterComponents(GameEntity entity)
        {
            entity.RemoveWeaponAnimator();
        }
    }
}
