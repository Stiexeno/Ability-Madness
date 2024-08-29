using Entitas;

namespace AbilityMadness.Code.Gameplay.Weapons.Systems
{
    public class RotateWeaponByDirectionSystem : IExecuteSystem
    {
        private IGroup<GameEntity> _weapons;
        private IGroup<GameEntity> _owners;
        private GameContext _gameContext;

        public RotateWeaponByDirectionSystem(GameContext gameContext)
        {
            _gameContext = gameContext;
            _weapons = gameContext.GetGroup(GameMatcher
                .AllOf(
                    GameMatcher.Weapon,
                    GameMatcher.Direction,
                    GameMatcher.OwnerId,
                    GameMatcher.WeaponAnimator));

            _owners = gameContext.GetGroup(GameMatcher
                .AllOf(
                    GameMatcher.Id,
                    GameMatcher.LookDirection,
                    GameMatcher.TargetsInSight));
        }

        public void Execute()
        {
            foreach (var weapon in _weapons)
            {
                var owner = _gameContext.GetEntityWithId(weapon.OwnerId);

                if (_owners.ContainsEntity(owner))
                {
                    weapon.WeaponAnimator.SetDirection(owner.LookDirection);

                    // if (owner.TargetsInSight.Count > 0)
                    // {
                    //     var closestTarget = owner.GetClosestTarget();
                    //     var direction = (closestTarget.WorldPosition - owner.WorldPosition).normalized;
                    // }
                }
            }
        }
    }
}
