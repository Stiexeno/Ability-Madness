using AbilityMadness.Code.Gameplay.Health;
using AbilityMadness.Code.Gameplay.Weapons;
using UnityEngine;

namespace AbilityMadness.Code.Gameplay.Projectile.Factory
{
    public interface IProjectileFactory
    {
        GameEntity CreateProjectile(ProjectileScheme scheme);
        GameEntity CreateProjectileRequest(BulletTypeId type, int abilityId, Vector3 position, Vector3 direction, Team team, int bulletDamage, float spread);
    }
}
