using AbilityMadness.Code.Gameplay.Gears.Configs;
using AbilityMadness.Code.Gameplay.Projectile.Factory;
using AbilityMadness.Code.Gameplay.Upgrades.Configs;
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

        public ProjectileSetup projectileSetup;
    }
}
