using Entitas;
using UnityEngine;

namespace AbilityMadness.Code.Gameplay.Modifiers
{
    [Game] public class Modifier : IComponent {  }
    [Game] public class ModifierValue : IComponent { public float Value; }
    [Game] public class ModifierTypeIdComponent : IComponent { public ModifierTypeId Value; }

    [Game] public class ForwardMovementModifier : IComponent { }
    [Game] public class ZigZagMovementModifier : IComponent { }

    [Game] public class ZigZagTimeElapsed : IComponent { public float Value; }
    [Game] public class ZigZagDirection : IComponent { public Vector2 Value; }

    [Game] public class SpeedModifier : IComponent { }
    [Game] public class MultishootModifier : IComponent { }

    [Game] public class Ricochet : IComponent { }
    [Game] public class RicochetModifier : IComponent { }
    [Game] public class RicochetHitCount : IComponent { public int Value; }
}
