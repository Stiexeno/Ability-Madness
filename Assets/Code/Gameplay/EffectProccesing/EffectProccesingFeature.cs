using AbilityMadness.Code.Gameplay.EffectProccesing.Systems;
using AbilityMadness.Code.Infrastructure.Services.ECS;

namespace AbilityMadness.Code.Gameplay.EffectProccesing
{
    public class EffectProccesingFeature : Feature
    {
        public EffectProccesingFeature(ISystemFactory systemFactory)
        {
            Add(systemFactory.Create<ApplyDamageEffectSystem>());

            Add(systemFactory.Create<UnapplyStatusesOnTargetDeathSystem>());

            Add(systemFactory.Create<CleanupEffectReceivedSystem>());
            Add(systemFactory.Create<CleanupEffectDealtSystem>());
        }
    }
}
