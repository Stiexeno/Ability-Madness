using AbilityMadness.Code.Gameplay.Weapons.Bullets.Configs;
using TMPro;
using UnityEngine.UI;
using SF = UnityEngine.SerializeField;

namespace AbilityMadness.Code.Gameplay.Upgrades.UI
{
    public class ItemDescriptionWindow : Window
    {
        [SF] private TMP_Text nameText;
        [SF] private Image icon;

        public void Setup(BulletConfig bulletConfig)
        {
            nameText.text = bulletConfig.name;
            icon.sprite = bulletConfig.icon;
        }
    }
}
