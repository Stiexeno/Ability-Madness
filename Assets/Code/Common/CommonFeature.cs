using AbilityMadness.Code.Common.Particles.Systems;
using AbilityMadness.Code.Infrastructure.Services.ECS;

namespace AbilityMadness.Code.Common
{
    public class CommonFeature : Feature
    {
        public CommonFeature(ISystemFactory systemFactory)
        {
            Add(systemFactory.Create<StopParticlesOnNullProducerSystem>());
            Add(systemFactory.Create<DestructParticlesSystem>());
        }
    }
}
