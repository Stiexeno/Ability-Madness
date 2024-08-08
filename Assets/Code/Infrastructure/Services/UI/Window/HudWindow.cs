using AbilityMadness.Code.Infrastructure.Services.UI.Widgets;
using SF = UnityEngine.SerializeField;

namespace AbilityMadness
{
    public class HudWindow : Window
    {
        [SF] private ExperienceWidget experienceWidget;
        [SF] private DamageFlashWidget damageFlashWidget;

        [SF] private AmmoWidget ammoWidget;

        public AmmoWidget AmmoWidget => ammoWidget;

        public void SetExperience(int experience, int maxExperience)
        {
            experienceWidget.SetExperience(experience, maxExperience);
        }

        public void DamageFlash()
        {
            damageFlashWidget.Flash();
        }
    }
}
