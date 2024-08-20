using Entitas;
using UnityEngine;

namespace AbilityMadness.Code.Gameplay.Projectile.Systems
{
    public class SlowdownProjectileSystem : IExecuteSystem
    {
        private const float SLOWDOWN_FACTOR = 50f;

        private IGroup<GameEntity> _projectiles;

        public SlowdownProjectileSystem(GameContext gameContext)
        {
            _projectiles = gameContext.GetGroup(GameMatcher
                .AllOf(
                    GameMatcher.Projectile,
                    GameMatcher.DistanceTraveled,
                    GameMatcher.Range,
                    GameMatcher.MovementSpeed));
        }

        public void Execute()
        {
            foreach (var projectile in _projectiles)
            {
                var normalizedDistance = projectile.DistanceTraveled / projectile.Range;

                if (normalizedDistance >= 0.8f)
                {
                    projectile.MovementSpeed -= SLOWDOWN_FACTOR * Time.deltaTime;

                    projectile.MovementSpeed = Mathf.Max(0, projectile.MovementSpeed);

                    if (projectile.MovementSpeed <= 0)
                    {
                        projectile.isDestructed = true;
                    }
                }
            }
        }
    }
}
