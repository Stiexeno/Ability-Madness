using AbilityMadness.Code.Gameplay.Status.Systems;
using AbilityMadness.Code.Gameplay.Status.Systems.Implementations;
using AbilityMadness.Code.Gameplay.Status.Systems.View;
using AbilityMadness.Code.Infrastructure.ECS;

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

            Add(systemFactory.Create<ApplyStatusViewSystem>());

            Add(systemFactory.Create<UnapplyStatusesOnTargetDeathSystem>());

            Add(systemFactory.Create<CleanupDepletedStatsChangesSystem>());
            Add(systemFactory.Create<CleanupDepletedStatusesSystem>());
        }
    }
}
