using AbilityMadness.Code.Gameplay.Upgrades.Configs;
using AbilityMadness.Code.Gameplay.Weapons.Bullets.Configs;
using AbilityMadness.Infrastructure.UI;
using UnityEngine.UI;
using Zenject;
using SF = UnityEngine.SerializeField;

namespace AbilityMadness.Code.Gameplay.Upgrades.UI.ItemSelection
{
    public class BulletSelectWidget : UpgradeSelectWidget
    {
        [SF] protected Image shadow;

        private ItemDescriptionWindow _descriptionWindow;
        private BulletConfig _bulletConfig;
        private IUpgradeSelectModel _upgradeSelectModel;

        [Inject]
        private void Construct(IUIService uiService, IUpgradeSelectModel upgradeSelectModel)
        {
            _upgradeSelectModel = upgradeSelectModel;
            _descriptionWindow = uiService.Get<ItemDescriptionWindow>();
        }

        public void Setup(ItemConfig item)
        {
            _bulletConfig = item as BulletConfig;
            icon.sprite = _bulletConfig.icon;
            shadow.sprite = _bulletConfig.icon;

            gameObject.SetActive(true);
        }

        private void OnDisable()
        {
            icon.gameObject.SetActive(true);
            selectIcon.SetActive(false);
        }

        public void Select()
        {
            icon.gameObject.SetActive(false);
            _upgradeSelectModel.Select(this, _bulletConfig).Forget();
        }

        public void Deselect()
        {
            icon.gameObject.SetActive(true);
        }

        protected override void OnHover()
        {
            _descriptionWindow.Setup(_bulletConfig);
        }

        protected override void OnClick()
        {
            Select();
        }
    }
}
