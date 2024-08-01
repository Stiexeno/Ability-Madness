using AbilityMadness.Code.Gameplay.DamageApplication.Systems;
using AbilityMadness.Code.Gameplay.DamageApplication.View;
using AbilityMadness.Code.Infrastructure.Services.ECS;

namespace AbilityMadness.Code.Gameplay.DamageApplication
{
    public class DamageFeature : Feature
    {
        public DamageFeature(ISystemFactory systemFactory)
        {
            Add(systemFactory.Create<ApplyDamageSystem>());

            Add(systemFactory.Create<PlayDamageAnimatorSystem>());
            Add(systemFactory.Create<ApplyDamageEffectSystem>());

            Add(systemFactory.Create<CleanupDamageReceivedSystem>());
        }
    }
}
