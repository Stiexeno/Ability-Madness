using TMPro;
using UnityEngine;
using SF = UnityEngine.SerializeField;

namespace AbilityMadness.Code.Gameplay.UI.Hud.Widgets
{
    public class HealthbarWidget : MonoBehaviour
    {
        [SF] private TMP_Text healthText;
        [SF] private Progressbar progressbar;

        public void SetHealth(int health, int maxHealth)
        {
            var progress = (float)health / maxHealth;
            progressbar.SetProgress(progress);

            healthText.text = $"{health}/{maxHealth}";
        }
    }
}
