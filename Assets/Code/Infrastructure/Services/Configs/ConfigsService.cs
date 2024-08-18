using System.Collections.Generic;
using AbilityMadness.Code.Gameplay.Enemy;
using AbilityMadness.Code.Gameplay.Enemy.Configs;
using AbilityMadness.Code.Gameplay.Gears.Configs;
using AbilityMadness.Code.Gameplay.Upgrades.Configs;
using AbilityMadness.Code.Gameplay.Weapons;
using AbilityMadness.Code.Gameplay.Weapons.Bullets.Configs;
using AbilityMadness.Code.Gameplay.Weapons.Configs;
using AbilityMadness.Code.Infrastructure.Services.Cursors;
using AbilityMadness.Code.Infrastructure.Services.Cursors.Configs;
using AbilityMadness.Code.Infrastructure.Services.WorldBuilder.Configs;
using AbilityMadness.Infrastructure.Services.Assets;
using Cysharp.Threading.Tasks;
using UnityEngine;

namespace AbilityMadness.Infrastructure.Services.Configs
{
	public class ConfigsService : IConfigsService
	{
		private IAssets _assets;

        public WorldBuilderConfig[] WorldBuilderConfigs { get; private set; }
        public WeaponConfig[] WeaponConfigs { get; private set; }
        public BulletConfig[] BulletConfigs { get; private set; }
        public GearConfig[] GearConfig { get; private set; }
        public EnemyConfig[] EnemyConfigs { get; private set; }

		public ConfigsService(IAssets assets)
		{
			_assets = assets;
			Load().Forget();
		}

		private async UniTaskVoid Load()
		{
            WorldBuilderConfigs = _assets.GetAssetsByLabel<WorldBuilderConfig>(Constants.Configs.WorldBuilderConfigLabel);
            WeaponConfigs = _assets.GetAssetsByLabel<WeaponConfig>(Constants.Configs.WeaponConfigLabel);
            BulletConfigs = _assets.GetAssetsByLabel<BulletConfig>(Constants.Configs.BulletConfigLabel);
            GearConfig = _assets.GetAssetsByLabel<GearConfig>(Constants.Configs.GearConfigLabel);
            EnemyConfigs = _assets.GetAssetsByLabel<EnemyConfig>(Constants.Configs.EnemyConfigLabel);
		}

        public async UniTask<CursorConfig> GetCursor(CursorType type)
        {
            var cursorConfig = await _assets.LoadAsync<CursorConfig>(Constants.Configs.CursorConfig);
            return cursorConfig;
        }

        public EnemyConfig GetEnemyConfig(EnemyTypeId type)
        {
            foreach (var enemyConfig in EnemyConfigs)
            {
                if (enemyConfig.type == type)
                {
                    return enemyConfig;
                }
            }

            Debug.LogError($"EnemyConfig with type {type} not found");
            return null;
        }

        public WeaponConfig GetWeaponConfig(WeaponTypeId type)
        {
            foreach (var weaponConfig in WeaponConfigs)
            {
                if (weaponConfig.weaponTypeId == type)
                {
                    return weaponConfig;
                }
            }

            Debug.LogError($"WeaponConfig with type {type} not found");
            return null;
        }

        public BulletConfig GetBulletConfig(BulletTypeId type)
        {
            foreach (var bulletConfig in BulletConfigs)
            {
                if (bulletConfig.type == type)
                {
                    return bulletConfig;
                }
            }

            Debug.LogError($"BulletConfig with type {type} not found");
            return null;
        }

        public WorldBuilderConfig GetWorldBuilderConfig(WorldType worldTyp)
        {
            foreach (var worldBuilderConfig in WorldBuilderConfigs)
            {
                if (worldBuilderConfig.worldType == worldTyp)
                {
                    return worldBuilderConfig;
                }
            }

            Debug.LogError($"WorldBuilderConfig with type {worldTyp} not found");
            return null;
        }

        public List<ItemConfig> GetItemConfigs()
        {
            var itemConfigs = new List<ItemConfig>();
            foreach (var bulletConfig in BulletConfigs)
            {
                if (bulletConfig is ItemConfig itemConfig)
                {
                    itemConfigs.Add(itemConfig);
                }
            }

            // foreach (var gearConfig in GearConfig)
            // {
            //     if (gearConfig is ItemConfig itemConfig)
            //     {
            //         itemConfigs.Add(itemConfig);
            //     }
            // }

            return itemConfigs;
        }
    }
}
