using AbilityMadness.Code.Gameplay.Movement.Systems;

namespace AbilityMadness.Code.Infrastructure.Services.ECS
{
    public class BattleLateUpdateFeature : Feature
    {
        public BattleLateUpdateFeature(ISystemFactory systemFactory)
        {
            Add(systemFactory.Create<SetWorldPositionByTransformSystem>());
        }
    }
}
