using AbilityMadness.Code.Common.Cooldown;
using Entitas;

namespace AbilityMadness.Code.Gameplay.Weapons.Systems
{
    public class WeaponCooldownOnReloadSystem : IExecuteSystem
    {
        private IGroup<GameEntity> _weapons;

        public WeaponCooldownOnReloadSystem(GameContext gameContext)
        {
            _weapons = gameContext.GetGroup(GameMatcher
                .AllOf(
                    GameMatcher.Weapon,
                    GameMatcher.AmmoCapacity,
                    GameMatcher.MaxAmmoCapacity,
                    GameMatcher.Shot,
                    GameMatcher.ReloadTime));
        }

        public void Execute()
        {
            foreach (var weapon in _weapons)
            {
                if (weapon.AmmoCapacity <= 0)
                {
                    weapon.isReloading = true;
                    weapon.SetOnCooldown(weapon.ReloadTime);
                }
            }
        }
    }
}
