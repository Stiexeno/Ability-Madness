using System.Collections.Generic;
using Entitas;

namespace AbilityMadness.Code.Gameplay.Weapons.Systems
{
    public class CleanupWeaponShotSystem : ICleanupSystem
    {
        private readonly List<GameEntity> _buffer = new(32);
        private IGroup<GameEntity> _weapons;

        public CleanupWeaponShotSystem(GameContext gameContext)
        {
            _weapons = gameContext.GetGroup(GameMatcher
                .AllOf(
                    GameMatcher.Weapon,
                    GameMatcher.Shot));
        }

        public void Cleanup()
        {
            foreach (var weapon in _weapons.GetEntities(_buffer))
            {
                weapon.isShot = false;
            }
        }
    }
}
