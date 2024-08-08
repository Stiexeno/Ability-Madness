using AbilityMadness.Code.Gameplay.Health;
using AbilityMadness.Code.Gameplay.Weapons;
using UnityEngine;

namespace AbilityMadness.Code.Gameplay.Projectile.Factory
{
    public class ProjectileScheme
    {
        public BulletTypeId type;
        public int producerId;

        public Vector3 position;
        public Vector2 direction;
        public Team team;

        public float movementSpeed = 0.15f;
        public int spawnCount = 1;
        public int damage = 10;
        public float spread = 0;
    }
}
