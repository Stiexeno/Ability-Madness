using AbilityMadness.Code.Gameplay.Abilities.Systems;
using AbilityMadness.Code.Infrastructure.Services.ECS;

namespace AbilityMadness.Code.Gameplay.Abilities
{
    public class AbilityFeature : Feature
    {
        public AbilityFeature(ISystemFactory systemFactory)
        {
            Add(systemFactory.Create<PrepareManualLaunchAbilitySystem>());
            Add(systemFactory.Create<AbilityCooldownSystem>());
            Add(systemFactory.Create<ProcessAblityCooldownSystem>());
        }
    }
}
