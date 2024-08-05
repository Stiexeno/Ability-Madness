using AbilityMadness.Code.Gameplay.Abilities;
using AbilityMadness.Code.Gameplay.Abilities.Configs;
using AbilityMadness.Code.Infrastructure.Services.Assembler;
using AbilityMadness.Code.Infrastructure.Services.Cursors.Configs;
using AbilityMadness.Infrastructure.Services.Assets;
using Cysharp.Threading.Tasks;
using UnityEngine;

namespace AbilityMadness.Infrastructure.Services.Configs
{
	public class ConfigsService : IConfigsService
	{
		private IAssets _assets;

        public CursorConfig CursorConfig { get; private set; }
        public AbilityConfig[] AbilityConfigs { get; private set; }
        public AttachmentConfig[] AttachmentConfigs { get; private set; }

		public ConfigsService(IAssets assets)
		{
			_assets = assets;
			Load().Forget();
		}

		private async UniTaskVoid Load()
		{
            CursorConfig = await _assets.LoadAsync<CursorConfig>(Constants.Configs.CursorConfig);
            AbilityConfigs = _assets.GetAssetsByLabel<AbilityConfig>(Constants.Configs.AbilityConfigLabel);
            AttachmentConfigs = _assets.GetAssetsByLabel<AttachmentConfig>(Constants.Configs.AttachmentConfigLabel);
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
    }
}
