using Entitas;

namespace AbilityMadness.Code.Gameplay.DamageApplication
{
    [Game] public class Damage : IComponent { public int Value; }
    [Game] public class DamageReceived : IComponent {  }
    [Game] public class DamageDealt : IComponent {  }

    [Game] public class DamageRequest : IComponent {  }
}
