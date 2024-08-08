using System.Collections.Generic;
using AbilityMadness.Code.Gameplay.Projectile.Factory;
using AbilityMadness.Code.Gameplay.Vision;
using Entitas;

namespace AbilityMadness.Code.Gameplay.Weapons.Systems
{
    public class WeaponTargetSystem : IExecuteSystem
    {
        private readonly List<GameEntity> _buffer = new(32);
        private readonly IGroup<GameEntity> _weapons;
        private readonly IGroup<GameEntity> _owners;
        private GameContext _gameContext;

        private IProjectileFactory _projectileFactory;

        public WeaponTargetSystem(GameContext gameContext, IProjectileFactory projectileFactory)
        {
            _projectileFactory = projectileFactory;
            _gameContext = gameContext;
            _weapons = gameContext.GetGroup(GameMatcher
                .AllOf(
                    GameMatcher.Weapon,
                    GameMatcher.AmmoCapacity,
                    GameMatcher.MaxAmmoCapacity,
                    GameMatcher.FireRate,
                    GameMatcher.AmmoIndex,
                    GameMatcher.Ready,
                    GameMatcher.Direction));

            _owners = gameContext.GetGroup(GameMatcher
                .AllOf(
                    GameMatcher.Id,
                    GameMatcher.WorldPosition,
                    GameMatcher.LookDirection,
                    GameMatcher.TargetsInSight));
        }

        public void Execute()
        {
            foreach (var weapon in _weapons.GetEntities(_buffer))
            {
                var owner = _gameContext.GetEntityWithId(weapon.OwnerId);

                if (_owners.ContainsEntity(owner))
                {
                    if (owner.TargetsInSight.Count > 0)
                    {
                        var closestTarget = owner.GetClosestTarget();
                        var direction = (closestTarget.WorldPosition - owner.WorldPosition).normalized;

                        weapon.isShot = true;
                        weapon.Direction = direction;
                    }
                }
            }
        }
    }
}
