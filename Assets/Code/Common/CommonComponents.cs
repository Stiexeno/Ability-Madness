using Entitas;
using Entitas.CodeGeneration.Attributes;
using UnityEngine;

namespace AbilityMadness.Code.Common
{
    [Game] public class Id : IComponent { [PrimaryEntityIndex] public int Value; }

    [Game] public class WorldPosition : IComponent { public Vector3 Value; }
    [Game] public class Transform : IComponent { public UnityEngine.Transform Value; }

    [Game] public class Rigidbody2D : IComponent { public UnityEngine.Rigidbody2D Value; }
}
