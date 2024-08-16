using AbilityMadness.Code.Gameplay.Abilities.Systems;
using AbilityMadness.Code.Gameplay.Weapons.Bullets.Systems;
using AbilityMadness.Code.Gameplay.Weapons.Systems;
using AbilityMadness.Code.Gameplay.Weapons.Systems.View;
using AbilityMadness.Code.Infrastructure.Services.ECS;

namespace AbilityMadness.Code.Gameplay.Weapons
{
    public class WeaponFeature : Feature
    {
        public WeaponFeature(ISystemFactory systemFactory)
        {
            Add(systemFactory.Create<RotateWeaponByDirectionSystem>());
            Add(systemFactory.Create<AttachWeaponToOwnerPositionSystem>());

            Add(systemFactory.Create<WeaponManualAttackReadySystem>());
            Add(systemFactory.Create<SetWeaponShotOnReadySystem>());

            //Add(systemFactory.Create<WeaponReadySystem>());
            //Add(systemFactory.Create<WeaponTargetSystem>());
            Add(systemFactory.Create<CreateProjectileRequestSystem>());

            Add(systemFactory.Create<ShakeOnShootSystem>());
            Add(systemFactory.Create<CreateReloadWidgetSystem>());
            Add(systemFactory.Create<RefreshReloadWidgetSystem>());
            Add(systemFactory.Create<DestructReloadWidgetSystem>());

            Add(systemFactory.Create<RefreshAmmoWidgetSystem>());
            Add(systemFactory.Create<PlayWeaponShotSystem>());

            Add(systemFactory.Create<IncreaseWeaponAmmoIndexSystem>());

            Add(systemFactory.Create<WeaponCooldownOnReloadSystem>());
            Add(systemFactory.Create<WeaponCooldownBetweenShotsSystem>());

            Add(systemFactory.Create<SendBulletEntitiesToServiceSystem>());

            Add(systemFactory.Create<ReloadWeaponSystem>());
            Add(systemFactory.Create<RecoverWeaponSystem>());

            Add(systemFactory.Create<CleanupWeaponShotSystem>());
        }
    }
}
