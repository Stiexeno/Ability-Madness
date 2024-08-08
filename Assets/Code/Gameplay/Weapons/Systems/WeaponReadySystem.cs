using Entitas;

namespace AbilityMadness.Code.Gameplay.Weapons.Systems
{
    public class WeaponReadySystem : IExecuteSystem
    {
        private IGroup<GameEntity> _weapons;

        public WeaponReadySystem(GameContext gameContext)
        {
            _weapons = gameContext.GetGroup(GameMatcher
                .AllOf(
                    GameMatcher.Weapon));
        }

        public void Execute()
        {
            foreach (var weapon in _weapons)
            {
                weapon.isReady = weapon.isReloading == false && weapon.isRecovering == false;
            }
        }
    }
}
