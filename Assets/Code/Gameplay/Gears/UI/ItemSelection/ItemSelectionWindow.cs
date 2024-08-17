using System.Collections.Generic;
using AbilityMadness.Code.Gameplay.Gears.Configs;
using AbilityMadness.Code.Gameplay.Gears.UI.Inventory;
using AbilityMadness.Code.Infrastructure.Services.Cursors;
using AbilityMadness.Code.Infrastructure.Services.TimeService;
using AbilityMadness.Code.Infrastructure.Services.UI;
using AbilityMadness.Infrastructure.Factories.UI;
using Cysharp.Threading.Tasks;
using UnityEngine;
using Zenject;
using SF = UnityEngine.SerializeField;

namespace AbilityMadness.Code.Gameplay.Gears.UI.ItemSelection
{
    public class ItemSelectionWindow : Window
    {
        [SF] private Transform content;

        private List<BulletSelectWidget> _bulletSelectWidgets = new();

        private IUIService _uiService;
        private ITimeService _timeService;
        private IUIFactory _uiFactory;
        private ICursorService _cursorService;
        private IUIPool _uiPool;

        [Inject]
        private void Construct(
            IUIService uiService,
            ITimeService timeService,
            IUIFactory uiFactory,
            ICursorService cursorService,
            IUIPool uiPool)
        {
            _uiPool = uiPool;
            _cursorService = cursorService;
            _uiFactory = uiFactory;
            _timeService = timeService;
            _uiService = uiService;
        }

        public async UniTaskVoid Setup(ItemConfig[] items)
        {
            foreach (var item in items)
            {
                BulletSelectWidget bulletWidget = await _uiFactory.CreateBulletSelectWidget(content);
                bulletWidget.Setup(item);

                _bulletSelectWidgets.Add(bulletWidget);
            }

            Open();
        }

        private void Cleanup()
        {
            foreach (var bulletSelectWidget in _bulletSelectWidgets)
            {
                _uiPool.Put(bulletSelectWidget);
            }

            _bulletSelectWidgets.Clear();
        }

        protected override void OnBeforeOpen()
        {
            _timeService.Pause();
            _cursorService.SetCursor(CursorType.Select);
            _uiService.Open<InventoryWindow>();
            _uiService.Open<ItemDescriptionWindow>();
        }

        protected override void OnBeforeClose()
        {
            Cleanup();

            _timeService.Resume();
            _cursorService.SetCursor(CursorType.Default);
            _uiService.Close<InventoryWindow>();
            _uiService.Close<ItemDescriptionWindow>();
        }
    }
}
