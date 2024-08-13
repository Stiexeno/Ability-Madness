using AbilityMadness.Code.Gameplay.Weapons.Bullets;
using UnityEngine;

namespace AbilityMadness.Code.Gameplay.Weapons.Configs
{
    [CreateAssetMenu(fileName = nameof(WeaponConfig), menuName = Constants.Root + "/Configs/WeaponConfig")]
    public class WeaponConfig : ScriptableObject
    {
        public WeaponTypeId weaponTypeId;

        public float fireRate = 0.1f;
        public float reloadTime = 1f;
        public float spread = 0f;
        public int spawnCount = 1;

        public BulletScheme[] bullets;
    }
}
