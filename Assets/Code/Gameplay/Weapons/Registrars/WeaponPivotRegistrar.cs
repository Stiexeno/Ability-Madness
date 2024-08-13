using AbilityMadness.Code.Infrastructure.View;
using UnityEngine;

namespace AbilityMadness.Code.Gameplay.Weapons.Registrars
{
    [EntityTag("Registrars")]
    public class WeaponPivotRegistrar : EntityComponentRegistrar
    {
        [SerializeField] private Transform pivot;

        public override void RegisterComponents(GameEntity entity)
        {
            entity.AddWeaponPivot(pivot);
        }

        public override void UnregisterComponents(GameEntity entity)
        {
            entity.RemoveWeaponPivot();
        }
    }
}
