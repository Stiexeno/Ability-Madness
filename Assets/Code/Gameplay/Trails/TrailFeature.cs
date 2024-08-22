using AbilityMadness.Code.Gameplay.Trails.Systems;
using AbilityMadness.Code.Infrastructure.ECS;

namespace AbilityMadness.Code.Gameplay.Trails
{
    public class TrailFeature : Feature
    {
        public TrailFeature(ISystemFactory systemFactory)
        {
            Add(systemFactory.Create<CreateAreaWithTrailSystem>());
            Add(systemFactory.Create<MarkTrailReadyOnDistanceTraveledSystem>());
        }
    }
}
