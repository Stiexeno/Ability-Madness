using AbilityMadness.Code.Gameplay.Health.Registrars;
using AbilityMadness.Code.Infrastructure.View;
using UnityEngine;
using SF = UnityEngine.SerializeField;

namespace AbilityMadness.Code.Gameplay.Health.Behaviours
{
    [RequireComponent(typeof(HealthbarRegistrar))]
    public class Healthbar : EntityComponent
    {
        [SF] private Progressbar progressbar;
        [SF] private Progressbar ghostProgressbar;

        public void SetHealth(float health)
        {
            progressbar.SetProgress(health);
            ghostProgressbar.SetProgress(health, 0.1f, 0.1f);
        }
    }
}
