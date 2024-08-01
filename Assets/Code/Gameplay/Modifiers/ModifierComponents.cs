using Entitas;

namespace AbilityMadness.Code.Gameplay.Modifiers
{
    [Game] public class Modifier : IComponent {  }
    [Game] public class ModifierTypeIdComponent : IComponent { public ModifierTypeId Value; }

    [Game] public class ForwardMovementModifier : IComponent { }
}
