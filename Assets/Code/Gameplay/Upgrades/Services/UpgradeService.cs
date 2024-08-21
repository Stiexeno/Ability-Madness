using System.Collections.Generic;
using AbilityMadness.Code.Gameplay.Upgrades.Configs;
using AbilityMadness.Code.Gameplay.Upgrades.UI.ItemSelection;
using AbilityMadness.Code.Infrastructure.Configs;
using AbilityMadness.Infrastructure.UI;
using UnityEngine;

namespace AbilityMadness.Code.Gameplay.Upgrades.Services
{
    public class UpgradeService : IUpgradeService
    {
        private List<ItemConfig> _itemPool = new();

        private const int MAX_ITEMS = 4;
        private readonly ItemConfig[] _generatedItems = new ItemConfig[MAX_ITEMS];

        private IConfigsService _configsService;
        private IUIService _uiService;

        public UpgradeService(IConfigsService configsService, IUIService uiService)
        {
            _uiService = uiService;
            _configsService = configsService;
        }

        public void Load()
        {
            var itemConfigs = _configsService.GetItemConfigs();
            _itemPool.AddRange(itemConfigs);
        }

        public void Upgrade()
        {
            var itemSelectWindow = _uiService.Get<UpgradeSelectionWindow>();
            itemSelectWindow.Setup(GetRandomItems()).Forget();
        }

        private ItemConfig[] GetRandomItems()
        {
            var itemPool = new List<ItemConfig>(_itemPool);

            for (var i = 0; i < MAX_ITEMS; i++)
            {
                _generatedItems[i] = GetRandomItem(ref itemPool);
            }

            return _generatedItems;
        }

        private ItemConfig GetRandomItem(ref List<ItemConfig> itemPool)
        {
            var totalChance = 0f;

            foreach (var item in itemPool)
            {
                totalChance += item.chance;
            }

            var randomValue = Random.Range(0f, totalChance);
            var cumulativeChance = 0f;

            foreach (var item in itemPool)
            {
                cumulativeChance += item.chance;

                if (randomValue < cumulativeChance)
                {
                    itemPool.Remove(item);
                    return item;
                }
            }

            Debug.LogError("No item was selected");
            return null;
        }
    }
}
