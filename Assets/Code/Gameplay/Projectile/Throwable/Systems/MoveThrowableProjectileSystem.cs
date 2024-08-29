using Entitas;
using UnityEngine;

namespace AbilityMadness.Code.Gameplay.Projectile.Systems.Implementations
{
    public class MoveThrowableProjectileSystem : IExecuteSystem
    {
        private IGroup<GameEntity> _projectiles;

        public MoveThrowableProjectileSystem(GameContext gameContext)
        {
            _projectiles = gameContext.GetGroup(GameMatcher
                .AllOf(
                    GameMatcher.Projectile,
                    GameMatcher.Throwable,
                    GameMatcher.TargetPosition,
                    GameMatcher.StartPosition,
                    GameMatcher.Velocity,
                    GameMatcher.WorldPosition));
        }

        public void Execute()
        {
            foreach (var projectile in _projectiles)
            {
                var distance = Vector3.Distance(projectile.TargetPosition, projectile.WorldPosition);

                var direction = (projectile.TargetPosition - projectile.StartPosition).normalized;

                if (distance <= 0.1f)
                {
                    projectile.isDepleted = true;
                    continue;
                }

                projectile.WorldPosition += direction * projectile.MovementSpeed * Time.deltaTime;
            }
        }
    }
}
