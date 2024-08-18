using System.Collections.Generic;
using AbilityMadness.Code.Gameplay.Status.Factory;
using Entitas;

namespace AbilityMadness.Code.Gameplay.Status
{
   [Game] public class Status : IComponent {  }

   [Game] public class StatusTypeIdComponent : IComponent { public StatusTypeId Value;  }
   [Game] public class StatusSetups : IComponent { public List<StatusSetup> Value;  }

   [Game] public class Period : IComponent { public float Value; }
   [Game] public class TimeSinceLastTick : IComponent { public float Value;}
   [Game] public class Applied : IComponent {  }
   [Game] public class Depleted : IComponent {  }

   [Game] public class Fire : IComponent {  }
   [Game] public class Freeze : IComponent {  }
   [Game] public class Poison : IComponent {  }
}
