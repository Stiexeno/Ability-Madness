using UnityEngine;

namespace AbilityMadness.Code.Gameplay.Weapons.Bullets.Configs
{
    [CreateAssetMenu(fileName = nameof(BulletConfig), menuName = Constants.Root + "/Configs/BulletConfig")]
    public class BulletConfig : ScriptableObject
    {
        public BulletTypeId type;

        public int damage;
        public float movementSpeed;
        public int pierce;
    }
}
