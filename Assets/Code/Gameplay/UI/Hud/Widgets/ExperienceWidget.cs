using UnityEngine;
using SF = UnityEngine.SerializeField;

namespace AbilityMadness.Code.Gameplay.UI.Hud.Widgets
{
    public class ExperienceWidget : MonoBehaviour
    {
        [SF] private Progressbar progressbar;

        public void SetExperience(int experience, int maxExperience)
        {
            var progress = (float)experience / maxExperience;
            progressbar.SetProgress(progress);
        }
    }
}
