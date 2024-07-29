using AbilityMadness.Code.Infrastructure.Services.Cursors.Configs;

namespace AbilityMadness.Infrastructure.Services.Configs
{
	public interface IConfigsService
	{
        CursorConfig CursorConfig { get; }
    }
}
