using AbilityMadness.Code.Gameplay.Projectile.Factory;
using Entitas;

namespace AbilityMadness.Code.Gameplay.Abilities.Systems.Implementation.Fireball
{
    public class FireballManualLaunchAbilitySystem : IExecuteSystem
    {
        private IGroup<GameEntity> _abilities;
        private GameContext _gameContext;
        private IProjectileFactory _projectileFactory;
        private IGroup<GameEntity> _owners;

        public FireballManualLaunchAbilitySystem(GameContext gameContext, IProjectileFactory projectileFactory)
        {
            _projectileFactory = projectileFactory;
            _gameContext = gameContext;

            _abilities = gameContext.GetGroup(GameMatcher
                .AllOf(
                    GameMatcher.Ability,
                    GameMatcher.FireballAbility,
                    GameMatcher.Ready,
                    GameMatcher.ProducerId,
                    GameMatcher.ManualLaunch));

            _owners = gameContext.GetGroup(GameMatcher
                .AllOf(
                    GameMatcher.WorldPosition,
                    GameMatcher.LookDirection));
        }

        public void Execute()
        {
            // foreach (var ability in _abilities)
            // {
            //     var owner = _gameContext.GetEntityWithId(ability.ProducerId);
            //
            //     if (_owners.ContainsEntity(owner))
            //     {
            //         _projectileFactory.CreateFireball(
            //             ability.Id,
            //             owner.WorldPosition,
            //             owner.LookDirection,
            //             ability.Team);
            //     }
            // }
        }
    }
}
