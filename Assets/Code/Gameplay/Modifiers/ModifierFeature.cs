using AbilityMadness.Code.Gameplay.Modifiers.Systems.Implemenation;
using AbilityMadness.Code.Gameplay.Modifiers.Systems.Implemenation.Ricochet;
using AbilityMadness.Code.Infrastructure.Services.ECS;

namespace AbilityMadness.Code.Gameplay.Modifiers
{
    public class ModifierFeature : Feature
    {
        public ModifierFeature(ISystemFactory systemFactory)
        {
            // Movements

            Add(systemFactory.Create<ForwardMovementModifierSystem>());
            Add(systemFactory.Create<ZigZagMovementModifierSystem>());

            Add(systemFactory.Create<SpeedModifierSystem>());
            Add(systemFactory.Create<MultishotModifierSystem>());

            Add(systemFactory.Create<ProjectileRicochetSystem>());
        }
    }
}
