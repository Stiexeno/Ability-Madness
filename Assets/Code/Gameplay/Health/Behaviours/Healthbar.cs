using AbilityMadness.Code.Gameplay.Health.Registrars;
using AbilityMadness.Code.Infrastructure.Services.UI;
using AbilityMadness.Code.Infrastructure.View;
using UnityEngine;
using Zenject;
using SF = UnityEngine.SerializeField;

namespace AbilityMadness.Code.Gameplay.Health.Behaviours
{
    [RequireComponent(typeof(HealthbarRegistrar))]
    public class Healthbar : EntityComponent
    {
        [SF] private Progressbar progressbar;

        private IUIPool _uiPool;

        [Inject]
        private void Construct(IUIPool uiPool)
        {
            _uiPool = uiPool;
        }

        public void Hide()
        {
            _uiPool.Put(this);
        }

        public void SetHealth(float health)
        {
            progressbar.SetValue(health);
        }
    }
}
