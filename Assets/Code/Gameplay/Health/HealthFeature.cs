using AbilityMadness.Code.Gameplay.Health.Systems;
using AbilityMadness.Code.Infrastructure.Services.ECS;

namespace AbilityMadness.Code.Gameplay.Health
{
    public class HealthFeature : Feature
    {
        public HealthFeature(ISystemFactory systemFactory)
        {
            Add(systemFactory.Create<MarkLifeStateSystem>());
            Add(systemFactory.Create<PlayDeathAnimationSystem>());
            Add(systemFactory.Create<DestructHealthbarOnTargetDeathSystem>());
            Add(systemFactory.Create<DisplayHealthbarSystem>());

            Add(systemFactory.Create<FinalizeDeathProccessing>());
        }
    }
}
