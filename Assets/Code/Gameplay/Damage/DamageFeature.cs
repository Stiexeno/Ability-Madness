using AbilityMadness.Code.Gameplay.DamageApplication.Systems.View;
using AbilityMadness.Code.Infrastructure.Services.ECS;

namespace AbilityMadness.Code.Gameplay.DamageApplication
{
    public class DamageFeature : Feature
    {
        public DamageFeature(ISystemFactory systemFactory)
        {
            // Apply Damage Modifiers Here
            //...

            Add(systemFactory.Create<PlayDamageAnimatorSystem>());
           // Add(systemFactory.Create<ApplyDamageVFXSystem>());
            Add(systemFactory.Create<ShowDamageTextSystem>());
        }
    }
}
