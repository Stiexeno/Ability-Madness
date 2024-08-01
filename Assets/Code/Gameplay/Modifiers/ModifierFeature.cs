using AbilityMadness.Code.Gameplay.Modifiers.Systems.Implemenation;
using AbilityMadness.Code.Infrastructure.Services.ECS;

namespace AbilityMadness.Code.Gameplay.Modifiers
{
    public class ModifierFeature : Feature
    {
        public ModifierFeature(ISystemFactory systemFactory)
        {
            Add(systemFactory.Create<ForwardMovementModifierSystem>());
        }
    }
}
