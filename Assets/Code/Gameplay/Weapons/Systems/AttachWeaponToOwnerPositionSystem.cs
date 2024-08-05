using Entitas;

namespace AbilityMadness.Code.Gameplay.Weapons.Systems
{
    public class AttachWeaponToOwnerPositionSystem : IExecuteSystem
    {
        private IGroup<GameEntity> _weapons;
        private IGroup<GameEntity> _owners;
        private GameContext _gameContext;

        public AttachWeaponToOwnerPositionSystem(GameContext gameContext)
        {
            _gameContext = gameContext;
            _weapons = gameContext.GetGroup(GameMatcher
                .AllOf(
                    GameMatcher.Weapon,
                    GameMatcher.OwnerId,
                    GameMatcher.WorldPosition,
                    GameMatcher.Offset));

            _owners = gameContext.GetGroup(GameMatcher
                .AllOf(
                    GameMatcher.Id,
                    GameMatcher.WorldPosition));
        }

        public void Execute()
        {
            foreach (var weapon in _weapons)
            {
                var owner = _gameContext.GetEntityWithId(weapon.OwnerId);

                if (_owners.ContainsEntity(owner))
                {
                    weapon.WorldPosition = owner.WorldPosition + weapon.Offset;
                }
            }
        }
    }
}
