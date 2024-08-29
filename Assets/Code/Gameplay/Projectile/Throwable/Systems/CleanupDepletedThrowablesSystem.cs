using Entitas;

namespace AbilityMadness.Code.Gameplay.Projectile.Systems.Implementations
{
    public class CleanupDepletedThrowablesSystem : ICleanupSystem
    {
        private IGroup<GameEntity> _throwables;

        public CleanupDepletedThrowablesSystem(GameContext gameContext)
        {
            _throwables = gameContext.GetGroup(GameMatcher
                .AllOf(
                    GameMatcher.Throwable,
                    GameMatcher.Depleted));
        }

        public void Cleanup()
        {
            foreach (var throwable in _throwables)
            {
                throwable.isDestructed = true;
            }
        }
    }
}
