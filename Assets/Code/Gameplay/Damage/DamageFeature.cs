using AbilityMadness.Code.Gameplay.DamageApplication.Systems.View;
using AbilityMadness.Code.Infrastructure.ECS;

namespace AbilityMadness.Code.Gameplay.DamageApplication
{
    public class DamageFeature : Feature
    {
        public DamageFeature(ISystemFactory systemFactory)
        {
            Add(systemFactory.Create<PlayDamageAnimatorSystem>());
            Add(systemFactory.Create<ShowDamageTextSystem>());
        }
    }
}
