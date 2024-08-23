using AbilityMadness.Code.Gameplay.Gears.Configs;
using AbilityMadness.Code.Gameplay.Gears.Factory;
using AbilityMadness.Code.Gameplay.Upgrades.Configs;
using AbilityMadness.Code.Gameplay.Upgrades.Services;
using AbilityMadness.Infrastructure.UI;
using Zenject;

namespace AbilityMadness.Code.Gameplay.Upgrades.UI.ItemSelection
{
    public class GearSelectWidget : UpgradeSelectWidget
    {
        private GearConfig _gearConfig;
        private IUIService _uiService;
        private ItemDescriptionWindow _descriptionWindow;
        private IGearFactory _gearFactory;
        private IUpgradeService _upgradeService;

        [Inject]
        private void Construct(IUIService uiService, IGearFactory gearFactory, IUpgradeService upgradeService)
        {
            _upgradeService = upgradeService;
            _gearFactory = gearFactory;
            _uiService = uiService;
            _descriptionWindow = uiService.Get<ItemDescriptionWindow>();
        }

        public void Setup(ItemConfig item)
        {
            _gearConfig = item as GearConfig;
            icon.sprite = _gearConfig.icon;

            gameObject.SetActive(true);
        }

        private void OnDisable()
        {
            icon.gameObject.SetActive(true);
            selectIcon.SetActive(false);
        }

        protected override void OnHover()
        {
            _descriptionWindow.Setup(_gearConfig);
        }

        protected override void OnClick()
        {
            if (_gearConfig.unique)
            {
                _upgradeService.RemoveFromPool(_gearConfig);
            }

            _gearFactory.CreateGearRequest(_gearConfig.type);
            _uiService.Close<UpgradeSelectionWindow>();
        }
    }
}
