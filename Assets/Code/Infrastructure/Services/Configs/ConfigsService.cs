using AbilityMadness.Code.Gameplay.Abilities;
using AbilityMadness.Code.Gameplay.Abilities.Configs;
using AbilityMadness.Code.Gameplay.Weapons;
using AbilityMadness.Code.Gameplay.Weapons.Bullets.Configs;
using AbilityMadness.Code.Gameplay.Weapons.Configs;
using AbilityMadness.Code.Infrastructure.Services.Assembler;
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

        public AbilityConfig[] AbilityConfigs { get; private set; }
        public AttachmentConfig[] AttachmentConfigs { get; private set; }
        public WorldBuilderConfig[] WorldBuilderConfigs { get; private set; }
        public WeaponConfig[] WeaponConfigs { get; private set; }
        public BulletConfig[] BulletConfigs { get; private set; }

		public ConfigsService(IAssets assets)
		{
			_assets = assets;
			Load().Forget();
		}

		private async UniTaskVoid Load()
		{
            AbilityConfigs = _assets.GetAssetsByLabel<AbilityConfig>(Constants.Configs.AbilityConfigLabel);
            AttachmentConfigs = _assets.GetAssetsByLabel<AttachmentConfig>(Constants.Configs.AttachmentConfigLabel);
            WorldBuilderConfigs = _assets.GetAssetsByLabel<WorldBuilderConfig>(Constants.Configs.WorldBuilderConfigLabel);
            WeaponConfigs = _assets.GetAssetsByLabel<WeaponConfig>(Constants.Configs.WeaponConfigLabel);
            BulletConfigs = _assets.GetAssetsByLabel<BulletConfig>(Constants.Configs.BulletConfigLabel);
		}

        public async UniTask<Texture2D> GetCursor(CursorType type)
        {
            var cursorConfig = await _assets.LoadAsync<CursorConfig>(Constants.Configs.CursorConfig);
            return cursorConfig.GetCursor(type);
        }

        public AbilityConfig GetAbilityConfig(AbilityTypeId type)
        {
            foreach (var abilityConfig in AbilityConfigs)
            {
                if (abilityConfig.type == type)
                {
                    return abilityConfig;
                }
            }

            Debug.LogError($"AbilityConfig with type {type} not found");
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
    }
}
