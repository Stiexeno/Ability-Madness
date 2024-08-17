using AbilityMadness.Code.Gameplay.Gears.Configs;
using AbilityMadness.Code.Gameplay.Weapons.Bullets.Configs;
using UnityEngine.UI;
using Zenject;
using SF = UnityEngine.SerializeField;

namespace AbilityMadness.Code.Gameplay.Gears.UI.ItemSelection
{
    public class BulletSelectWidget : ItemSelectWidget
    {
        [SF] protected Image shadow;

        private ItemDescriptionWindow _descriptionWindow;
        private BulletConfig _bulletConfig;
        private IItemSelectModel _itemSelectModel;

        [Inject]
        private void Construct(IUIService uiService, IItemSelectModel itemSelectModel)
        {
            _itemSelectModel = itemSelectModel;
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
            _itemSelectModel.Select(this, _bulletConfig).Forget();
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
