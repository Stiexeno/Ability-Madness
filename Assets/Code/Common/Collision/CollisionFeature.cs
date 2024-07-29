using AbilityMadness.Code.Common.Collision.Systems;
using AbilityMadness.Code.Infrastructure.Services.ECS;

namespace AbilityMadness.Code.Common.Collision
{
    public class CollisionFeature : Feature
    {
        public CollisionFeature(ISystemFactory systemFactory)
        {
            Add(systemFactory.Create<CleanupCollisionSystem>());
        }
    }
}