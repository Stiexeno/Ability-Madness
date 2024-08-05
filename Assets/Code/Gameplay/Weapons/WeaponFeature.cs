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
        }
    }
}
