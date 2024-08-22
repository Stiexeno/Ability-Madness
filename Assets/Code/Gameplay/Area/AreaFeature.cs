using AbilityMadness.Code.Gameplay.Area.Systems;
using AbilityMadness.Code.Infrastructure.ECS;

namespace AbilityMadness.Code.Gameplay.Area
{
    public class AreaFeature : Feature
    {
        public AreaFeature(ISystemFactory systemFactory)
        {
            Add(systemFactory.Create<ApplyAreaStatusSystem>());
            Add(systemFactory.Create<AreaDurationSystem>());
        }
    }
}
