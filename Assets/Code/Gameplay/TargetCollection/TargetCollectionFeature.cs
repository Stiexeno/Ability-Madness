using AbilityMadness.Code.Gameplay.TargetCollection.Systems;
using AbilityMadness.Code.Infrastructure.ECS;

namespace AbilityMadness.Code.Gameplay.TargetCollection
{
    public class TargetCollectionFeature : Feature
    {
        public TargetCollectionFeature(ISystemFactory systemFactory)
        {
            Add(systemFactory.Create<CollectTargetsWithSphereCastSystem>());
            Add(systemFactory.Create<CleanupTargetBufferSystem>());
        }
    }
}
