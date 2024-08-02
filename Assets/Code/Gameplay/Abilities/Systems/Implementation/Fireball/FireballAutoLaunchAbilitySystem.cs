using AbilityMadness.Code.Gameplay.Modifiers;
using AbilityMadness.Code.Gameplay.Projectile.Factory;
using AbilityMadness.Code.Gameplay.Vision;
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
        private IGroup<GameEntity> _modifiers;

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

            _modifiers = gameContext.GetGroup(GameMatcher
                .AllOf(
                    GameMatcher.Modifier,
                    GameMatcher.MultishootModifier,
                    GameMatcher.ModifierValue));
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
                        var closestTarget = owner.GetClosestTarget();
                        var direction = (closestTarget.WorldPosition - owner.WorldPosition).normalized;

                        ShootProjectile(ability, direction, owner);
                    }
                }
            }
        }

        private void ShootProjectile(GameEntity ability, Vector3 direction, GameEntity owner)
        {
            foreach (var modifier in _modifiers)
            {
                if (modifier.TargetId == ability.Id)
                {
                    for (int i = 0; i < modifier.ModifierValue; i++)
                    {
                        var multishotDirection = ModifierExtensions.GetMultishotDirection(
                            direction,
                            Mathf.RoundToInt(modifier.ModifierValue),
                            i);

                        _projectileFactory.CreateFireball(
                            ability.Id,
                            owner.WorldPosition,
                            multishotDirection,
                            ability.Team);
                    }

                    return;
                }
            }

            _projectileFactory.CreateFireball(
                ability.Id,
                owner.WorldPosition,
                direction,
                ability.Team);
        }
    }
}
