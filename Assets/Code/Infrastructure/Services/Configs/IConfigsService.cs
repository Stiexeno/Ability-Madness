using AbilityMadness.Code.Gameplay.Abilities;
using AbilityMadness.Code.Gameplay.Abilities.Configs;
using AbilityMadness.Code.Infrastructure.Services.Cursors.Configs;

namespace AbilityMadness.Infrastructure.Services.Configs
{
	public interface IConfigsService
	{
        CursorConfig CursorConfig { get; }
        AbilityConfig GetAbilityConfig(AbilityTypeId type);
    }
}
