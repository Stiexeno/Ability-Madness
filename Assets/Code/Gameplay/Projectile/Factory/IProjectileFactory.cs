using AbilityMadness.Code.Gameplay.Health;
using UnityEngine;

namespace AbilityMadness.Code.Gameplay.Projectile.Factory
{
    public interface IProjectileFactory
    {
        GameEntity CreateFireball(int abilityId, Vector3 position, Vector3 direction, Team abilityTeam);
        GameEntity CreateTornado(int abilityId, Vector3 position, Vector3 direction, Team team);
        GameEntity CreateProjectile(ProjectileTypeId type, int abilityId, Vector3 position, Vector3 direction, Team team);
        GameEntity CreateProjectileRequest(ProjectileTypeId type, int abilityId, Vector3 position, Vector3 direction, Team team);
    }
}
