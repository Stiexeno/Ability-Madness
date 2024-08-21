using System.Collections.Generic;
using AbilityMadness.Code.Gameplay.Weapons.Bullets.Services;
using AbilityMadness.Code.Infrastructure.Services.UI;
using AbilityMadness.Code.Infrastructure.UI.Factory;
using AbilityMadness.Infrastructure.UI;
using Cysharp.Threading.Tasks;
using UnityEngine;
using Zenject;
using SF = UnityEngine.SerializeField;

namespace AbilityMadness.Code.Gameplay.Upgrades.UI.Inventory
{
    public class InventoryWindow : Window
    {
        [SF] private Transform content;

        private List<BulletWidget> _bulletWidgets = new();

        private IBulletService _bulletService;
        private IUIFactory _uiFactory;
        private IUIPool _uiPool;

        [Inject]
        private void Construct(IBulletService bulletService, IUIFactory uiFactory, IUIPool uiPool)
        {
            _uiPool = uiPool;
            _uiFactory = uiFactory;
            _bulletService = bulletService;
        }

        protected override void OnBeforeOpen()
        {
            SetupBullets().Forget();
        }

        private void Cleanup()
        {
            foreach (var bulletWidget in _bulletWidgets)
            {
                _uiPool.Put(bulletWidget);
            }

            _bulletWidgets.Clear();
        }

        private async UniTaskVoid SetupBullets()
        {
            Cleanup();
            var bulletConfigs = _bulletService.GetBulletConfigs();

            for (var i = 0; i < bulletConfigs.Length; i++)
            {
                var bulletConfig = bulletConfigs[i];
                var bulletWidget = await _uiFactory.CreateBulletWidget(content);
                bulletWidget.Setup(bulletConfig, i);

                _bulletWidgets.Add(bulletWidget);
            }
        }
    }
}
