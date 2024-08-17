using AbilityMadness.Code.Gameplay.Gears.UI.Inventory;
using AbilityMadness.Code.Gameplay.Weapons.Bullets.Configs;
using AbilityMadness.Code.Infrastructure.Services.UI;
using AbilityMadness.Infrastructure.Factories.UI;
using Cysharp.Threading.Tasks;
using UnityEngine.InputSystem;
using Zenject;

namespace AbilityMadness.Code.Gameplay.Gears.UI.ItemSelection
{
    public class ItemSelectModel : IItemSelectModel, ITickable
    {
        private BulletConfig _bulletConfig;
        private BulletSelectWidget _bulletSelectWidget;
        private BulletDragWidget _bulletDragWidget;

        private bool _isActive;

        private InputAction _rightClickAction;

        private IUIService _uiService;
        private IUIFactory _uiFactory;
        private IUIPool _uiPool;

        public ItemSelectModel(IUIService uiService, IUIFactory uiFactory, PlayerInput playerInput, IUIPool uiPool)
        {
            _rightClickAction = playerInput.actions[Constants.Input.RightClick];

            _uiPool = uiPool;
            _uiFactory = uiFactory;
            _uiService = uiService;
        }

        private void Cleanup()
        {
            _bulletSelectWidget = null;
            _bulletConfig = null;
        }

        public async UniTaskVoid Select(BulletSelectWidget bulletSelectWidget, BulletConfig bulletConfig)
        {
            if (ReplaceIfExists(bulletSelectWidget))
                return;

            _isActive = true;
            _bulletSelectWidget = bulletSelectWidget;
            _bulletConfig = bulletConfig;

            var overlayWindow = _uiService.Get<OverlayWindow>();
            _bulletDragWidget = await _uiFactory.CreateBulletDragWidget(overlayWindow.transform);
            _bulletDragWidget.Setup(_bulletConfig);
        }

        public void Replace(BulletWidget bulletWidget)
        {
            bulletWidget.Replace(_bulletConfig);
            _bulletDragWidget.Replace(bulletWidget.transform, () =>
            {
                bulletWidget.Setup(_bulletConfig);
                Cleanup();

                _uiService.Close<ItemSelectionWindow>();
            });
        }

        private bool ReplaceIfExists(BulletSelectWidget bulletSelectWidget)
        {
            if (IsAnySelected())
            {
                if (_bulletSelectWidget == bulletSelectWidget)
                {
                    Deselect();
                    return true;
                }

                Deselect();
            }

            return false;
        }

        public void Deselect()
        {
            _bulletSelectWidget.Deselect();
            _uiPool.Put(_bulletDragWidget);

            _bulletConfig = null;
            _bulletSelectWidget = null;
        }

        public bool IsAnySelected()
        {
            return _bulletConfig != null;
        }

        public BulletSelectWidget GetSelectedWidget()
        {
            return _bulletSelectWidget;
        }

        public void Tick()
        {
            if (_isActive &&
                _bulletConfig != null &&
                _rightClickAction.triggered)
            {
                Deselect();
            }
        }
    }
}