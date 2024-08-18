using AbilityMadness.Code.Gameplay.DamageApplication.OnDamageDealt.Systems;
using AbilityMadness.Code.Gameplay.DamageApplication.Systems;
using AbilityMadness.Code.Gameplay.DamageApplication.Systems.View;
using AbilityMadness.Code.Infrastructure.Services.ECS;

namespace AbilityMadness.Code.Gameplay.DamageApplication
{
    public class DamageFeature : Feature
    {
        public DamageFeature(ISystemFactory systemFactory)
        {
            Add(systemFactory.Create<CreateDamageRequestOnTargetBufferSystem>());

            // Apply Damage Modifiers Here
            //...

            // Apply Damage
            Add(systemFactory.Create<ApplyDamageWithRequestSystem>());

            // On Damage Received and Damage Dealt
            Add(systemFactory.Create<HealOnDamageDealtSystem>());

            Add(systemFactory.Create<PlayDamageAnimatorSystem>());
           // Add(systemFactory.Create<ApplyDamageVFXSystem>());
            Add(systemFactory.Create<ShowDamageTextSystem>());

            // Cleanup
            Add(systemFactory.Create<CleanupDamageReceivedSystem>());
            Add(systemFactory.Create<CleanupDamageDealtSystem>());
            Add(systemFactory.Create<CleanupDamageRequestSystem>());
        }
    }
}
