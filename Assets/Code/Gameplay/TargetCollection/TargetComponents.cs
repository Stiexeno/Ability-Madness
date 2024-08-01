using System.Collections.Generic;
using Entitas;

namespace AbilityMadness.Code.Gameplay.TargetCollection
{
    public class TargetBuffer : IComponent { public List<int> Value; }
    public class ProccessedTargets : IComponent { public List<int> Value; }
    public class SphereCast : IComponent {  }
    public class SphereCastRadius : IComponent { public float Value; }
}
