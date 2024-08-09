using Entitas;

namespace AbilityMadness.Code.Gameplay.Projectile.Systems
{
    public class IncreaseProjectilePierceOnDamageDealtSystem : IExecuteSystem
    {
        private IGroup<GameEntity> _projectiles;

        public IncreaseProjectilePierceOnDamageDealtSystem(GameContext gameContext)
        {
            _projectiles = gameContext.GetGroup(GameMatcher
                .AllOf(
                    GameMatcher.Projectile,
                    GameMatcher.PiercedAmount,
                    GameMatcher.DamageDealt));
        }

        public void Execute()
        {
            foreach (var projectile in _projectiles)
            {
                projectile.PiercedAmount++;
            }
        }
    }
}
