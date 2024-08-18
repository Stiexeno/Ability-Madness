using AbilityMadness.Code.Gameplay.DamageApplication.Systems;
using AbilityMadness.Code.Gameplay.EffectApplication.Systems;
using AbilityMadness.Code.Infrastructure.Services.ECS;

namespace AbilityMadness.Code.Gameplay.EffectApplication
{
    public class EffectApplicationFeature : Feature
    {
        public EffectApplicationFeature(ISystemFactory systemFactory)
        {
            Add(systemFactory.Create<CreateEffectOnTargetsSystem>());
            Add(systemFactory.Create<ApplyDamageEffectSystem>());

            // Cleanup
            Add(systemFactory.Create<CleanupEffectReceivedSystem>());
            Add(systemFactory.Create<CleanupEffectDealtSystem>());
            Add(systemFactory.Create<CleanupEffectApplicationSystem>());
        }
    }
}
