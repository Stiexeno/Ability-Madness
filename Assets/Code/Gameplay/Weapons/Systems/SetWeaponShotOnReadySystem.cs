using Entitas;

namespace AbilityMadness.Code.Gameplay.Weapons.Systems
{
    public class SetWeaponShotOnReadySystem : IExecuteSystem
    {
        private IGroup<GameEntity> _weapons;

        public SetWeaponShotOnReadySystem(GameContext gameContext)
        {
            _weapons = gameContext.GetGroup(GameMatcher
                .AllOf(
                    GameMatcher.Weapon,
                    GameMatcher.Ready));
        }

        public void Execute()
        {
            foreach (var weapon in _weapons)
            {
                weapon.isShot = true;
            }
        }
    }
}
