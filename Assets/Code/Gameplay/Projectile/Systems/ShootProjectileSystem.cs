using AbilityMadness.Code.Gameplay.Projectile.Factory;
using Entitas;

namespace AbilityMadness.Code.Gameplay.Projectile.Systems
{
    public class ShootProjectileSystem : IExecuteSystem
    {
        private IGroup<GameEntity> _abilities;
        private IProjectileFactory _projectileFactory;
        private Contexts _contexts;

        public ShootProjectileSystem(Contexts contexts, IProjectileFactory projectileFactory)
        {
            _contexts = contexts;
            _projectileFactory = projectileFactory;

            _abilities = contexts.game.GetGroup(GameMatcher
                .AllOf(
                    GameMatcher.Ability,
                    GameMatcher.Ready,
                    GameMatcher.OwnerId,
                    GameMatcher.Team));
        }

        public void Execute()
        {
            foreach (var ability in _abilities)
            {
                var owner = _contexts.game.GetEntityWithId(ability.OwnerId);
                var entity = _projectileFactory.CreateFireball(owner.WorldPosition, owner.LookDirection);
                entity.AddTeam(ability.Team);
            }
        }
    }
}
