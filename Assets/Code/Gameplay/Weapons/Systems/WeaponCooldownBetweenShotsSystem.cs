using AbilityMadness.Code.Common.Cooldown;
using Entitas;

namespace AbilityMadness.Code.Gameplay.Weapons.Systems
{
    public class WeaponCooldownBetweenShotsSystem : IExecuteSystem
    {
        private IGroup<GameEntity> _weapons;

        public WeaponCooldownBetweenShotsSystem(GameContext gameContext)
        {
            _weapons = gameContext.GetGroup(GameMatcher
                .AllOf(
                    GameMatcher.Weapon,
                    GameMatcher.Shot,
                    GameMatcher.FireRate)
                .NoneOf(
                    GameMatcher.Reloading));
        }

        public void Execute()
        {
            foreach (var weapon in _weapons)
            {
                weapon.isRecovering = true;
                weapon.SetOnCooldown(weapon.FireRate);
            }
        }
    }
}
