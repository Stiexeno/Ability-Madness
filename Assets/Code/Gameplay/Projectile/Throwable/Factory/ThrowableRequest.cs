using AbilityMadness.Code.Gameplay.Health;
using AbilityMadness.Code.Gameplay.Weapons;
using UnityEngine;
using UnityEngine.AddressableAssets;

namespace AbilityMadness.Code.Gameplay.Projectile.Factory
{
    public struct ThrowableRequest
    {
        public BulletTypeId type;
        public int ownerId;
        public int producerId;
        public AssetReferenceGameObject assetRef;

        public Vector3 position;

        public Vector3 targetPosition;
        public Team team;
    }
}
