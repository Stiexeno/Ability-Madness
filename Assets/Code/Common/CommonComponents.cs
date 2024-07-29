using Entitas;
using Entitas.CodeGeneration.Attributes;
using UnityEngine;

namespace AbilityMadness.Code.Common
{
    [Game] public class Id : IComponent { [PrimaryEntityIndex] public int Value; }

    [Game] public class WorldPosition : IComponent { public Vector3 Value; }
    [Game] public class TransformComponent : IComponent { public UnityEngine.Transform Value; }
    [Game] public class Velocity : IComponent { public Vector3 Value; }

    [Game] public class Rigidbody2DComponent : IComponent { public Rigidbody2D Value; }
    [Game] public class Collider2DComponent : IComponent { public Collider2D Value; }
}
