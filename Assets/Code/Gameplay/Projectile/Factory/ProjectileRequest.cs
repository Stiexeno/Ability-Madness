using AbilityMadness.Code.Gameplay.Health;
using AbilityMadness.Code.Gameplay.Weapons;
using UnityEngine;
using UnityEngine.AddressableAssets;

namespace AbilityMadness.Code.Gameplay.Projectile.Factory
{
    public struct ProjectileRequest
    {
        public BulletTypeId type;
        public int ownerId;
        public int producerId;
        public AssetReferenceGameObject assetRef;

        public Vector3 position;
        public Vector2 direction;
        public Team team;

        public float spread;
    }
}
