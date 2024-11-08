using AbilityMadness.Code.Gameplay.Gears.Systems;
using AbilityMadness.Code.Gameplay.Gears.Systems.Implementations;
using AbilityMadness.Code.Infrastructure.ECS;

namespace AbilityMadness.Code.Gameplay.Gears
{
    public class GearFeature : Feature
    {
        public GearFeature(ISystemFactory systemFactory)
        {
            Add(systemFactory.Create<CreateGearForPlayerSystem>());

            Add(systemFactory.Create<ApplyGearStatsSystem>());
            Add(systemFactory.Create<ApplyGearTrailSystem>());

            Add(systemFactory.Create<MarkGearAppliedSystem>());
        }
    }
}
