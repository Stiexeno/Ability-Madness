using AbilityMadness.Code.Common.Systems;
using AbilityMadness.Code.Infrastructure.Services.ECS;

namespace AbilityMadness.Code.Common
{
    public class CommonFeature : Feature
    {
        public CommonFeature(ISystemFactory systemFactory)
        {
            Add(systemFactory.Create<SetWorldPositionToTransformSystem>());
        }
    }
}
