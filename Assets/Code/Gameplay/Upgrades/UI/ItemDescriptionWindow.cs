using AbilityMadness.Code.Gameplay.Gears.Configs;
using AbilityMadness.Code.Gameplay.Weapons.Bullets.Configs;
using AbilityMadness.Infrastructure.UI;
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

        public void Setup(GearConfig gearConfig)
        {
            nameText.text = gearConfig.name;
            icon.sprite = gearConfig.icon;
        }
    }
}
