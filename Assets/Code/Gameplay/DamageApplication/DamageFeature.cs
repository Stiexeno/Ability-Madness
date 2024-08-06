using AbilityMadness.Code.Gameplay.DamageApplication.Systems;
using AbilityMadness.Code.Gameplay.DamageApplication.Systems.View;
using AbilityMadness.Code.Infrastructure.Services.ECS;

namespace AbilityMadness.Code.Gameplay.DamageApplication
{
    public class DamageFeature : Feature
    {
        public DamageFeature(ISystemFactory systemFactory)
        {
            Add(systemFactory.Create<ApplyDamageToTargetBufferSystem>());

            Add(systemFactory.Create<PlayDamageAnimatorSystem>());
            Add(systemFactory.Create<ApplyDamageVFXSystem>());
            Add(systemFactory.Create<ShowDamageTextSystem>());

            Add(systemFactory.Create<CleanupDamageReceivedSystem>());
            Add(systemFactory.Create<CleanupDamageDealtSystem>());
        }
    }
}
