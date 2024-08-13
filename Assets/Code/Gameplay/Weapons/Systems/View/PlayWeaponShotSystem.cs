using Entitas;

namespace AbilityMadness.Code.Gameplay.Weapons.Systems.View
{
    public class PlayWeaponShotSystem : IExecuteSystem
    {
        private IGroup<GameEntity> _weapons;

        public PlayWeaponShotSystem(GameContext gameContext)
        {
            _weapons = gameContext.GetGroup(GameMatcher
                .AllOf(
                    GameMatcher.Weapon,
                    GameMatcher.Shot,
                    GameMatcher.WeaponAnimator));
        }

        public void Execute()
        {
            foreach (var weapon in _weapons)
            {
                weapon.WeaponAnimator.Shoot();
            }
        }
    }
}
