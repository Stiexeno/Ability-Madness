using AbilityMadness.Code.Gameplay.Lifetime.Systems;
using AbilityMadness.Code.Infrastructure.Services.ECS;

namespace AbilityMadness.Code.Gameplay.Lifetime
{
    public class LifetimeFeature : Feature
    {
        public LifetimeFeature(ISystemFactory systemFactory)
        {
            Add(systemFactory.Create<ProcessLifetimeSystem>());
            Add(systemFactory.Create<ProcessTimeElapsedSystem>());
        }
    }
}
