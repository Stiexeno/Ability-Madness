using AbilityMadness.Code.Gameplay.DamageApplication.Systems;
using AbilityMadness.Code.Gameplay.EffectProccesing.Systems;
using AbilityMadness.Code.Infrastructure.Services.ECS;

namespace AbilityMadness.Code.Gameplay.EffectApplication
{
    public class EffectApplicationFeature : Feature
    {
        public EffectApplicationFeature(ISystemFactory systemFactory)
        {
            Add(systemFactory.Create<CreateEffectOnTargetsSystem>());

            // Cleanup
            Add(systemFactory.Create<CleanupEffectApplicationSystem>());
        }
    }
}
