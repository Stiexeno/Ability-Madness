using UnityEngine;

namespace AbilityMadness.Code.Gameplay.Projectile.Factory
{
    public interface IProjectileFactory
    {
        GameEntity CreateFireball(Vector3 position, Vector3 direction);
    }
}
