using AbilityMadness.Code.Gameplay.Modifiers.Factory;
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
        public int damage;
        public float movementSpeed;
        public int pierce;

        public ModifierScheme[] modifiers;
    }
}
