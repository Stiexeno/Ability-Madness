using AbilityMadness.Code.Gameplay.Projectile.Factory;
using AbilityMadness.Code.Gameplay.Vision;
using Entitas;

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
                    GameMatcher.AbilityProjectile,
                    GameMatcher.ProjectileTypeId,
                    GameMatcher.Ready,
                    GameMatcher.ProducerId,
                    GameMatcher.AutoLaunch,
                    GameMatcher.Team));

            _owners = gameContext.GetGroup(GameMatcher
                .AllOf(
                    GameMatcher.Id,
                    GameMatcher.WorldPosition,
                    GameMatcher.LookDirection,
                    GameMatcher.TargetsInSight));
        }

        public void Execute()
        {
            // foreach (var ability in _abilities)
            // {
            //     var owner = _gameContext.GetEntityWithId(ability.ProducerId);
            //
            //     if (_owners.ContainsEntity(owner))
            //     {
            //         if (owner.TargetsInSight.Count > 0)
            //         {
            //             var closestTarget = owner.GetClosestTarget();
            //             var direction = (closestTarget.WorldPosition - owner.WorldPosition).normalized;
            //
            //             _projectileFactory.CreateProjectileRequest(
            //                 ability.ProjectileTypeId,
            //                 ability.Id,
            //                 owner.WorldPosition,
            //                 direction,
            //                 ability.Team);
            //         }
            //     }
            // }
        }
    }
}
