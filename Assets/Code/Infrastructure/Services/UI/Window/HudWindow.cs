using AbilityMadness.Code.Infrastructure.Services.UI.Widgets;
using SF = UnityEngine.SerializeField;

namespace AbilityMadness
{
    public class HudWindow : Window
    {
        [SF] private ExperienceWidget experienceWidget;
        [SF] private HealthbarWidget healthbarWidget;
        [SF] private DamageFlashWidget damageFlashWidget;
        [SF] private RoundTimeWidget roundTimeWidget;

        [SF] private AmmoWidget ammoWidget;

        public AmmoWidget AmmoWidget => ammoWidget;

        public void SetHealth(int health, int maxHealth)
        {
            healthbarWidget.SetHealth(health, maxHealth);
        }

        public void SetExperience(int experience, int maxExperience)
        {
            experienceWidget.SetExperience(experience, maxExperience);
        }

        public void SetRoundTime(int roundTime)
        {
            roundTimeWidget.SetRoundTime(roundTime);
        }

        public void DamageFlash()
        {
            damageFlashWidget.Flash();
        }
    }
}
