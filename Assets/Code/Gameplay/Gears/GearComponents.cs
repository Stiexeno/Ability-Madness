using Entitas;

namespace AbilityMadness.Code.Gameplay.Gears
{
    [Game] public class Gear : IComponent { }
    [Game] public class GearRequest : IComponent { }
    [Game] public class GearTypeIdComponent : IComponent { public GearTypeId Value; }

    [Game] public class NotApplied : IComponent {  }
}
