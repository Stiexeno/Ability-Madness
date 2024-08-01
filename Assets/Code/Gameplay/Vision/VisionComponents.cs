using System.Collections.Generic;
using Entitas;

namespace AbilityMadness.Code.Gameplay.Vision
{
    [Game] public class Vision : IComponent {  }
    [Game] public class VisionRadius : IComponent { public float Value; }
    [Game] public class VisionLayer : IComponent { public int Value; }
    [Game] public class TargetsInSight : IComponent { public List<int> Value; }
    [Game] public class VisionTimer : IComponent { public float Value; }
    [Game] public class VisionInterval : IComponent { public float Value; }
}
