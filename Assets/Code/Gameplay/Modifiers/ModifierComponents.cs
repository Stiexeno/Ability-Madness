using Entitas;

namespace AbilityMadness.Code.Gameplay.Modifiers
{
    [Game] public class Modifier : IComponent {  }
    [Game] public class Modifiable : IComponent {  }
    [Game] public class ModifierValue : IComponent { public float Value; }
    [Game] public class ModifierTypeIdComponent : IComponent { public ModifierTypeId Value; }

    [Game] public class RicochetHitCount : IComponent { public int Value; }

    [Game] public class LifeStealModifier : IComponent {  }
    [Game] public class LifeSteal : IComponent { public float Value; }

    [Game] public class FireModifier : IComponent {  }
    [Game] public class FireValue : IComponent { public float Value; }
}
