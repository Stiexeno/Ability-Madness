using AbilityMadness.Code.Gameplay.Projectile;
using AbilityMadness.Code.Gameplay.Projectile.Factory;
using AbilityMadness.Code.Gameplay.Upgrades.Configs;
using Sirenix.OdinInspector;
using UnityEngine;
using UnityEngine.AddressableAssets;

namespace AbilityMadness.Code.Gameplay.Weapons.Bullets.Configs
{
    [CreateAssetMenu(fileName = nameof(BulletConfig), menuName = Constants.Root + "/Configs/BulletConfig")]
    public class BulletConfig : ItemConfig
    {
        [Space(10)]
        public BulletTypeId type;
        public AssetReferenceGameObject projectileRef;

        public int spawnCount = 1;

        [Space(15)]
        public ProjectileTypeId projectileType;

        [ShowIf("projectileType", ProjectileTypeId.Directional), HideLabel]
        public ProjectileSetup projectileSetup;

        [ShowIf("projectileType", ProjectileTypeId.Throwable), HideLabel]
        public ThrowableSetup throwableSetup;

        [ShowIf("projectileType", ProjectileTypeId.Beam), HideLabel]
        public BeamSetup beamSetup;

        [ShowIf("projectileType", ProjectileTypeId.Spawning), HideLabel]
        public SpawningSetup spawningSetup;
    }
}
