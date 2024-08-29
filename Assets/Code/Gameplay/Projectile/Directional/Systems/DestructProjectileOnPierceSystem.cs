using Entitas;

namespace AbilityMadness.Code.Gameplay.Projectile.Systems
{
    public class DestructProjectileOnPierceSystem : IExecuteSystem
    {
        private IGroup<GameEntity> _projectiles;

        public DestructProjectileOnPierceSystem(GameContext gameContext)
        {
            _projectiles = gameContext.GetGroup(GameMatcher
                .AllOf(
                    GameMatcher.Projectile,
                    GameMatcher.Pierce,
                    GameMatcher.PiercedAmount));
        }

        public void Execute()
        {
            foreach (var projectile in _projectiles)
            {
                if (projectile.PiercedAmount >= projectile.Pierce)
                {
                    projectile.isDestructed = true;
                }
            }
        }
    }
}
