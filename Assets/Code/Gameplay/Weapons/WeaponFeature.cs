using AbilityMadness.Code.Gameplay.Weapons.Systems;
using AbilityMadness.Code.Infrastructure.Services.ECS;

namespace AbilityMadness.Code.Gameplay.Weapons
{
    public class WeaponFeature : Feature
    {
        public WeaponFeature(ISystemFactory systemFactory)
        {
            Add(systemFactory.Create<RotateWeaponByDirectionSystem>());
            Add(systemFactory.Create<AttachWeaponToOwnerPositionSystem>());

            Add(systemFactory.Create<WeaponReadySystem>());
            Add(systemFactory.Create<WeaponTargetSystem>());
            Add(systemFactory.Create<CreateWeaponRequestSystem>());

            Add(systemFactory.Create<IncreaseWeaponAmmoIndexSystem>());

            Add(systemFactory.Create<WeaponCooldownOnReloadSystem>());
            Add(systemFactory.Create<WeaponCooldownBetweenShotsSystem>());

            Add(systemFactory.Create<ReloadWeaponSystem>());
            Add(systemFactory.Create<RecoverWeaponSystem>());

            Add(systemFactory.Create<CleanupWeaponShotSystem>());
        }
    }
}
