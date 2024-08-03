using Entitas;
using Entitas.CodeGeneration.Attributes;
using UnityEngine;

namespace AbilityMadness.Code.Common
{
    [Game] public class Id : IComponent { [PrimaryEntityIndex] public int Value; }
    [Game] public class OwnerId : IComponent { public int Value; }
    [Game] public class ProducerId : IComponent { public int Value; }
    [Game] public class TargetId : IComponent { public int Value; }

    [Game] public class WorldPosition : IComponent { public Vector3 Value; }
    [Game] public class TransformComponent : IComponent { public UnityEngine.Transform Value; }
    [Game] public class Velocity : IComponent { public Vector3 Value; }

    [Game] public class CooldownComponent : IComponent { public float Value; }
    [Game] public class CooldownLeft : IComponent { public float Value; }
    [Game] public class CooldownUp : IComponent {  }

    [Game] public class Interval : IComponent { public float Value; }
    [Game] public class TimeElapsed : IComponent { public float Value; }

    [Game] public class SpawnAmount : IComponent { public int Value; }

    [Game] public class Rigidbody2DComponent : IComponent { public Rigidbody2D Value; }
    [Game] public class Collider2DComponent : IComponent { public Collider2D Value; }
}
