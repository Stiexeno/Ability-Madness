using System.Collections.Generic;
using Entitas;

namespace AbilityMadness.Code.Gameplay.Weapons.Systems
{
    public class ReloadWeaponSystem : IExecuteSystem
    {
        private readonly List<GameEntity> _buffer = new(32);
        private IGroup<GameEntity> _weapons;

        public ReloadWeaponSystem(GameContext gameContext)
        {
            _weapons = gameContext.GetGroup(GameMatcher
                .AllOf(
                    GameMatcher.Weapon,
                    GameMatcher.Reloading,
                    GameMatcher.CooldownUp,
                    GameMatcher.AmmoCapacity,
                    GameMatcher.MaxAmmoCapacity));
        }

        public void Execute()
        {
            foreach (var weapon in _weapons.GetEntities(_buffer))
            {
                weapon.AmmoCapacity = weapon.MaxAmmoCapacity;
                weapon.isReloading = false;
            }
        }
    }
}
