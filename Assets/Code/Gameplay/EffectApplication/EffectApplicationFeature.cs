using AbilityMadness.Code.Gameplay.DamageApplication.Systems;
using AbilityMadness.Code.Infrastructure.ECS;

namespace AbilityMadness.Code.Gameplay.EffectApplication
{
    public class EffectApplicationFeature : Feature
    {
        public EffectApplicationFeature(ISystemFactory systemFactory)
        {
            Add(systemFactory.Create<CreateEffectOnTargetsSystem>());

            // Cleanup
           // Add(systemFactory.Create<CleanupEffectApplicationSystem>());
        }
    }
}
