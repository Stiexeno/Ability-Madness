using AbilityMadness.Code.Gameplay.Health;
using AbilityMadness.Code.Gameplay.Weapons;
using UnityEngine;
using UnityEngine.AddressableAssets;

namespace AbilityMadness.Code.Gameplay.Projectile.Factory
{
    public class ProjectileScheme
    {
        public BulletTypeId type;
        public int ownerId;
        public int producerId;
        public AssetReferenceGameObject assetRef;

        public Vector3 position;
        public Vector2 direction;
        public Team team;

        public float movementSpeed = 0.15f;
        public int spawnCount = 1;
        public int damage = 10;
        public float spread = 0;
        public int pierce = 1;
    }
}
