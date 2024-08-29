using Entitas;
using UnityEngine;

namespace AbilityMadness.Code.Gameplay.Projectile.Systems
{
    public class FaceProjectileToDirectionSystem : IExecuteSystem
    {
        private IGroup<GameEntity> _projectiles;

        public FaceProjectileToDirectionSystem(Contexts contexts)
        {
            _projectiles = contexts.game.GetGroup(GameMatcher
                .AllOf(
                    GameMatcher.Projectile,
                    GameMatcher.Direction,
                    GameMatcher.Transform,
                    GameMatcher.FaceToDirection));
        }

        public void Execute()
        {
            foreach (var projectile in _projectiles)
            {
                projectile.Transform.rotation = Quaternion.Euler(0, 0, Mathf.Atan2(projectile.Direction.y, projectile.Direction.x) * Mathf.Rad2Deg);
            }
        }
    }
}
