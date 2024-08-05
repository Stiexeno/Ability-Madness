using Entitas;

namespace AbilityMadness.Code.Gameplay.Abilities
{
    [Game] public class Ability : IComponent {  }
    [Game] public class ProducedByAbility : IComponent {  }
    [Game] public class AbilityTypeIdComponent : IComponent { public AbilityTypeId Value; }

    [Game] public class AbilityProjectile : IComponent {  }

    [Game] public class Ready : IComponent {  }
    [Game] public class Proccessed : IComponent {  }

    [Game] public class AutoLaunch : IComponent {  }
    [Game] public class ManualLaunch : IComponent {  }

    [Game] public class FireballAbility : IComponent {  }
    [Game] public class TornadoAbility : IComponent {  }
}
