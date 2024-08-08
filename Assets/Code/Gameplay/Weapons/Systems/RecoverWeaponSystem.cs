using System.Collections.Generic;
using Entitas;

namespace AbilityMadness.Code.Gameplay.Weapons.Systems
{
    public class RecoverWeaponSystem : IExecuteSystem
    {
        private readonly List<GameEntity> _buffer = new(32);
        private IGroup<GameEntity> _weapons;

        public RecoverWeaponSystem(GameContext gameContext)
        {
            _weapons = gameContext.GetGroup(GameMatcher
                .AllOf(
                    GameMatcher.Weapon,
                    GameMatcher.Recovering,
                    GameMatcher.CooldownUp,
                    GameMatcher.AmmoCapacity,
                    GameMatcher.MaxAmmoCapacity));
        }

        public void Execute()
        {
            foreach (var weapon in _weapons.GetEntities(_buffer))
            {
                weapon.isRecovering = false;
            }
        }
    }
}
