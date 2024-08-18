using AbilityMadness.Code.Gameplay.Modifiers.Systems.Implemenation.Ricochet;
using AbilityMadness.Code.Gameplay.Status.Systems;
using AbilityMadness.Code.Gameplay.Status.Systems.Implementations;
using AbilityMadness.Code.Infrastructure.Services.ECS;

namespace AbilityMadness.Code.Gameplay.Status
{
    public class StatusFeature : Feature
    {
        public StatusFeature(ISystemFactory systemFactory)
        {
            Add(systemFactory.Create<ApplyStatusesSystem>());
            Add(systemFactory.Create<StatusDurationSystem>());
            Add(systemFactory.Create<PeriodicDamageStatusSystem>());

            Add(systemFactory.Create<ApplyFreezeStatusSystem>());

            Add(systemFactory.Create<CleanupDepletedStatsChangesSystem>());
            Add(systemFactory.Create<CleanupDepletedStatusesSystem>());
        }
    }
}
