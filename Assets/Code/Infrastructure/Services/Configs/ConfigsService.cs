using AbilityMadness.Infrastructure.Services.Assets;

namespace AbilityMadness.Infrastructure.Services.Configs
{
	public class ConfigsService : IConfigsService
	{
		private IAssets _assets;

		public ConfigsService(IAssets assets)
		{
			_assets = assets;
			Load();
		}

		private void Load()
		{
		}
	}
}
