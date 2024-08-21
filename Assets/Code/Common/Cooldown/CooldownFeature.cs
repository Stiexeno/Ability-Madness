using AbilityMadness.Code.Common.Cooldown.Systems;
using AbilityMadness.Code.Infrastructure.ECS;

namespace AbilityMadness.Code.Common.Cooldown
{
    public class CooldownFeature : Feature
    {
        public CooldownFeature(ISystemFactory systemFactory)
        {
            Add(systemFactory.Create<ProcessCooldownSystem>());
            Add(systemFactory.Create<CleanupCooldownUpSystem>());
        }
    }
}
