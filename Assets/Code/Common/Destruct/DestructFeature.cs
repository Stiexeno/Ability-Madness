using AbilityMadness.Code.Common.Destruct.Systems;
using AbilityMadness.Code.Infrastructure.Services.ECS;

namespace AbilityMadness.Code.Common.Destruct
{
    public class DestructFeature : Feature
    {
        public DestructFeature(ISystemFactory systemFactory)
        {
            Add(systemFactory.Create<CleanupDestructedViewSystem>());
            Add(systemFactory.Create<CleanupDestructedSystem>());
        }
    }
}
