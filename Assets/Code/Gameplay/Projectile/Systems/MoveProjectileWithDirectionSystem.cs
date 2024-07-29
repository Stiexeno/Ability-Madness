using AbilityMadness.Code.Extensions;
using Entitas;

namespace AbilityMadness.Code.Gameplay.Projectile.Systems
{
    public class MoveProjectileWithDirectionSystem : IExecuteSystem
    {
        private IGroup<GameEntity> _projectiles;

        public MoveProjectileWithDirectionSystem(Contexts contexts)
        {
            _projectiles = contexts.game.GetGroup(GameMatcher
                .AllOf(
                    GameMatcher.Projectile,
                    GameMatcher.Direction,
                    GameMatcher.WorldPosition,
                    GameMatcher.MovementSpeed));
        }

        public void Execute()
        {
            foreach (var projectile in _projectiles)
            {
                projectile.WorldPosition += projectile.Direction.ToVector3() * projectile.MovementSpeed;
            }
        }
    }
}
