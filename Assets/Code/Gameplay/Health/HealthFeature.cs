using AbilityMadness.Code.Gameplay.Health.Systems;
using AbilityMadness.Code.Infrastructure.ECS;

namespace AbilityMadness.Code.Gameplay.Health
{
    public class HealthFeature : Feature
    {
        public HealthFeature(ISystemFactory systemFactory)
        {
            Add(systemFactory.Create<MarkLifeStateSystem>());
            Add(systemFactory.Create<PlayDeathAnimationSystem>());

            Add(systemFactory.Create<CreateHealthbarSystem>());
            Add(systemFactory.Create<RefreshHealthbarSystem>());
            Add(systemFactory.Create<RefreshHealthUISystem>());

            Add(systemFactory.Create<FinalizeDeathProccessing>());
            Add(systemFactory.Create<DestructHealthbarOnTargetDeathSystem>());
        }
    }
}
