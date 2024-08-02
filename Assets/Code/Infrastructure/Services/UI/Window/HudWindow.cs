using AbilityMadness.Code.Infrastructure.Services.UI.Widgets;
using SF = UnityEngine.SerializeField;

namespace AbilityMadness
{
    public class HudWindow : Window
    {
        [SF] private ExperienceWidget experienceWidget;

        public void SetExperience(int experience, int maxExperience)
        {
            experienceWidget.SetExperience(experience, maxExperience);
        }
    }
}
