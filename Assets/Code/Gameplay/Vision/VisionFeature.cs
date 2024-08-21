using AbilityMadness.Code.Gameplay.Vision.Systems;
using AbilityMadness.Code.Infrastructure.ECS;

namespace AbilityMadness.Code.Gameplay.Vision
{
    public class VisionFeature : Feature
    {
        public VisionFeature(ISystemFactory systemFactory)
        {
            Add(systemFactory.Create<ScanForTargetsSystem>());
        }
    }
}
