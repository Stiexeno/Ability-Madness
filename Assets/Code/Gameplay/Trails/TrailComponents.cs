using Entitas;

namespace AbilityMadness.Code.Gameplay.Trails
{
    [Game] public class Trail : IComponent {  }

    [Game] public class TrailTypeIdComponent : IComponent { public TrailTypeId Value; }
    [Game] public class DistanceThreshold : IComponent { public float Value; }
}
