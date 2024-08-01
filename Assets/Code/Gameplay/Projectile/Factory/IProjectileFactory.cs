using AbilityMadness.Code.Gameplay.Health;
using UnityEngine;

namespace AbilityMadness.Code.Gameplay.Projectile.Factory
{
    public interface IProjectileFactory
    {
        GameEntity CreateFireball(int abilityId, Vector3 position, Vector3 direction, Team abilityTeam);
        GameEntity CreateArrow(int abilityId, Vector3 position, Vector3 direction, Team team);
    }
}
