using Entitas;

namespace AbilityMadness.Code.Gameplay.Abilities.Systems
{
    public class WeaponManualAttackReadySystem : IExecuteSystem
    {
        private IGroup<GameEntity> _weapons;
        private GameContext _gameContext;
        private readonly IGroup<GameEntity> _owners;

        public WeaponManualAttackReadySystem(GameContext gameGameContext)
        {
            _gameContext = gameGameContext;

            _weapons = gameGameContext.GetGroup(GameMatcher
                .AllOf(
                    GameMatcher.Weapon,
                    GameMatcher.OwnerId));

            _owners = gameGameContext.GetGroup(GameMatcher
                .AllOf(
                    GameMatcher.WorldPosition,
                    GameMatcher.LookDirection));
        }

        public void Execute()
        {
            foreach (var weapon in _weapons)
            {
                var owner = _gameContext.GetEntityWithId(weapon.OwnerId);

                if (_owners.ContainsEntity(owner))
                {
                    weapon.isReady = owner.isAttacking &&
                                     weapon.isReloading == false &&
                                     weapon.isRecovering == false;

                    weapon.Direction = owner.LookDirection;
                }
            }
        }
    }
}
