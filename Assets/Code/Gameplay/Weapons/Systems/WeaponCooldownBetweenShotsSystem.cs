using System.Collections.Generic;
using AbilityMadness.Code.Common.Cooldown;
using Entitas;

namespace AbilityMadness.Code.Gameplay.Weapons.Systems
{
    public class WeaponCooldownBetweenShotsSystem : IExecuteSystem
    {
        private readonly List<GameEntity> _buffer = new(32);
        private IGroup<GameEntity> _weapons;

        public WeaponCooldownBetweenShotsSystem(GameContext gameContext)
        {
            _weapons = gameContext.GetGroup(GameMatcher
                .AllOf(
                    GameMatcher.Weapon,
                    GameMatcher.Shot,
                    GameMatcher.FireRate,
                    GameMatcher.Ready)
                .NoneOf(
                    GameMatcher.Reloading));
        }

        public void Execute()
        {
            foreach (var weapon in _weapons.GetEntities(_buffer))
            {
                weapon.isRecovering = true;
                weapon.SetOnCooldown(weapon.FireRate);
            }
        }
    }
}
