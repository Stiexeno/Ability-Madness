using AbilityMadness.Code.Gameplay.Abilities;
using AbilityMadness.Code.Gameplay.Abilities.Configs;
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
