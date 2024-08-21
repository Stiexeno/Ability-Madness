using AbilityMadness.Code.Gameplay.Modifiers.Systems.Implemenation.Ricochet;
using AbilityMadness.Code.Infrastructure.ECS;

namespace AbilityMadness.Code.Gameplay.Modifiers
{
    public class ModifierFeature : Feature
    {
        public ModifierFeature(ISystemFactory systemFactory)
        {
            Add(systemFactory.Create<ProjectileRicochetSystem>());
        }
    }
}
