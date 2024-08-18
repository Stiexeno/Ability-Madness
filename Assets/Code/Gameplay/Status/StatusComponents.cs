using Entitas;

namespace AbilityMadness.Code.Gameplay.Status
{
   [Game] public class Status : IComponent {  }
   [Game] public class StatusValue : IComponent { public float Value; }

   [Game] public class StatusTypeIdComponent : IComponent { public StatusTypeId Value;  }

   [Game] public class Depleted : IComponent {  }

   [Game] public class Fire : IComponent {  }
   [Game] public class Freeze : IComponent {  }
   [Game] public class Poison : IComponent {  }
}
