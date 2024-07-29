using AbilityMadness.Code.Infrastructure.Services.Cursors.Configs;
using AbilityMadness.Infrastructure.Services.Assets;

namespace AbilityMadness.Infrastructure.Services.Configs
{
	public class ConfigsService : IConfigsService
	{
		private IAssets _assets;

        public CursorConfig CursorConfig { get; private set; }

		public ConfigsService(IAssets assets)
		{
			_assets = assets;
			Load();
		}

		private void Load()
		{
            CursorConfig = _assets.Load<CursorConfig>(Constants.Configs.CursorConfig);
		}
	}
}
