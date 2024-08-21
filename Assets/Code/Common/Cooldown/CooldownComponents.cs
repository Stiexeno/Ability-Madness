using Entitas;

namespace AbilityMadness.Code.Common.Cooldown
{
    [Game] public class CooldownComponent : IComponent { public float Value; }
    [Game] public class CooldownLeft : IComponent { public float Value; }
    [Game] public class CooldownUp : IComponent {  }

    [Game] public class Duration : IComponent { public float Value; }
    [Game] public class TimeLeft : IComponent { public float Value; }
}
