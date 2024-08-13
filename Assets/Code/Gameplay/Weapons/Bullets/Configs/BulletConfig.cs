using AbilityMadness.Code.Gameplay.Projectile.Factory;
using Sirenix.OdinInspector;
using UnityEngine;
using UnityEngine.AddressableAssets;

namespace AbilityMadness.Code.Gameplay.Weapons.Bullets.Configs
{
    [CreateAssetMenu(fileName = nameof(BulletConfig), menuName = Constants.Root + "/Configs/BulletConfig")]
    public class BulletConfig : ScriptableObject
    {
        [PreviewField] public Sprite icon;
        public string name;

        [Space(10)]
        public BulletTypeId type;
        public AssetReferenceGameObject projectileRef;

        public ProjectileSetup projectileSetup;
    }
}
