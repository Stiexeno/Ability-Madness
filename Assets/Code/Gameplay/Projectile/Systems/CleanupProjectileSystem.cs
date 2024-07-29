using Entitas;
using UnityEngine;

namespace AbilityMadness.Code.Gameplay.Projectile.Systems
{
    public class CleanupProjectileSystem : ICleanupSystem
    {
        private IGroup<GameEntity> _projectiles;

        public CleanupProjectileSystem(Contexts contexts)
        {
            _projectiles = contexts.game.GetGroup(GameMatcher
                .AllOf(
                    GameMatcher.Projectile,
                    GameMatcher.LifeTime));
        }

        public void Cleanup()
        {
            foreach (var projectile in _projectiles)
            {
                projectile.LifeTime -= Time.deltaTime;

                if (projectile.LifeTime <= 0)
                {
                    projectile.isDestructed = true;
                }
            }
        }
    }
}
