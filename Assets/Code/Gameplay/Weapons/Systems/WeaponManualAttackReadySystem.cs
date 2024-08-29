using Entitas;

namespace AbilityMadness.Code.Gameplay.Abilities.Systems
{
    public class WeaponManualAttackReadySystem : IExecuteSystem
    {
        private IGroup<GameEntity> _weapons;
        private GameContext _gameContext;
        private readonly IGroup<GameEntity> _owners;
        private IGroup<GameEntity> _inputs;

        public WeaponManualAttackReadySystem(GameContext gameContext)
        {
            _gameContext = gameContext;

            _weapons = gameContext.GetGroup(GameMatcher
                .AllOf(
                    GameMatcher.Weapon,
                    GameMatcher.OwnerId));

            _owners = gameContext.GetGroup(GameMatcher
                .AllOf(
                    GameMatcher.WorldPosition,
                    GameMatcher.LookDirection));

            _inputs = gameContext.GetGroup(GameMatcher
                .AllOf(
                    GameMatcher.Input,
                    GameMatcher.MousePosition));
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

                    foreach (var input in _inputs)
                    {
                        weapon.TargetPosition = input.MousePosition;
                    }
                }
            }
        }
    }
}
