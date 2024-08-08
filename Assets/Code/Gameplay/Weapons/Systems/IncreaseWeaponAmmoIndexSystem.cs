using Entitas;

namespace AbilityMadness.Code.Gameplay.Weapons.Systems
{
    public class IncreaseWeaponAmmoIndexSystem : IExecuteSystem
    {
        private IGroup<GameEntity> _weapons;

        public IncreaseWeaponAmmoIndexSystem(GameContext gameContext)
        {
            _weapons = gameContext.GetGroup(GameMatcher
                .AllOf(
                    GameMatcher.Weapon,
                    GameMatcher.Shot,
                    GameMatcher.AmmoIndex,
                    GameMatcher.AmmoCapacity,
                    GameMatcher.MaxAmmoCapacity));
        }

        public void Execute()
        {
            foreach (var weapon in _weapons)
            {
                weapon.AmmoCapacity--;

                if (weapon.AmmoIndex >= weapon.MaxAmmoCapacity - 1)
                {
                    weapon.AmmoIndex = 0;
                    continue;
                }

                weapon.AmmoIndex++;
            }
        }
    }
}
