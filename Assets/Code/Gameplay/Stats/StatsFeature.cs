using AbilityMadness.Code.Gameplay.Stats.Systems;
using AbilityMadness.Code.Infrastructure.Services.ECS;

namespace AbilityMadness.Code.Gameplay.Stats
{
    public class StatsFeature : Feature
    {
        public StatsFeature(ISystemFactory systemFactory)
        {
            Add(systemFactory.Create<ResetStatsModifiersSystem>());
            Add(systemFactory.Create<ApplyStatsModifiersSystem>());

            Add(systemFactory.Create<MovementSpeedStatsSystem>());
            Add(systemFactory.Create<MaxHealthStatsSystem>());
        }
    }
}
