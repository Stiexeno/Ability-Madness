using AbilityMadness.Code.Infrastructure.Services.Assembler;
using AbilityMadness.Infrastructure.Factories.UI;
using Cysharp.Threading.Tasks;
using UnityEngine;
using Zenject;
using SF = UnityEngine.SerializeField;

namespace AbilityMadness.Code.Gameplay.UI.Upgrade
{
    public class UpgradeWindow : Window
    {
        [SF] private Transform content;

        private IUIFactory _uiFactory;
        private IUIService _uiService;

        [Inject]
        private void Construct(IUIService uiService, IUIFactory uiFactory)
        {
            _uiService = uiService;
            _uiFactory = uiFactory;
        }

        public async UniTaskVoid DisplayUpgrades(AttachmentConfig[] configs)
        {
            foreach (var config in configs)
            {
                var upgradeWidget = await _uiFactory.CreateUpgradeWidget(content);
                upgradeWidget.Setup(config);
            }

            Open();
        }
    }
}
