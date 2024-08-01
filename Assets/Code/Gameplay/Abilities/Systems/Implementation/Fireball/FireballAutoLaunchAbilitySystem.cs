using AbilityMadness.Code.Gameplay.Projectile.Factory;
using Entitas;
using UnityEngine;

namespace AbilityMadness.Code.Gameplay.Abilities.Systems.Implementation.Fireball
{
    public class FireballAutoLaunchAbilitySystem : IExecuteSystem
    {
        private IGroup<GameEntity> _abilities;
        private GameContext _gameContext;
        private IProjectileFactory _projectileFactory;
        private IGroup<GameEntity> _owners;

        public FireballAutoLaunchAbilitySystem(GameContext gameContext, IProjectileFactory projectileFactory)
        {
            _projectileFactory = projectileFactory;
            _gameContext = gameContext;

            _abilities = gameContext.GetGroup(GameMatcher
                .AllOf(
                    GameMatcher.Ability,
                    GameMatcher.FireballAbility,
                    GameMatcher.Ready,
                    GameMatcher.ProducerId,
                    GameMatcher.AutoLaunch));

            _owners = gameContext.GetGroup(GameMatcher
                .AllOf(
                    GameMatcher.WorldPosition,
                    GameMatcher.LookDirection,
                    GameMatcher.TargetsInSight));
        }

        public void Execute()
        {
            foreach (var ability in _abilities)
            {
                var owner = _gameContext.GetEntityWithId(ability.ProducerId);

                if (_owners.ContainsEntity(owner))
                {
                    if (owner.TargetsInSight.Count > 0)
                    {
                        var closestTarget = GetClosestTarget(owner);
                        var direction = (closestTarget.WorldPosition - owner.WorldPosition).normalized;

                        _projectileFactory.CreateFireball(
                            ability.Id,
                            owner.WorldPosition,
                            direction,
                            ability.Team);
                    }
                }
            }
        }

        private GameEntity GetClosestTarget(GameEntity attacker)
        {
            var distance = float.MaxValue;
            var closestTarget = default(GameEntity);

            foreach (var target in attacker.TargetsInSight)
            {
                var targetEntity = _gameContext.GetEntityWithId(target);
                var newDistance = Vector3.Distance(attacker.WorldPosition, targetEntity.WorldPosition);

                if (newDistance < distance)
                {
                    distance = newDistance;
                    closestTarget = targetEntity;
                }
            }

            return closestTarget;
        }
    }
}
