using Entitas;
using UnityEngine;

namespace AbilityMadness.Code.Gameplay.Movement
{
    [Game] public class Direction : IComponent { public Vector2 Value; }
    [Game] public class LookDirection : IComponent { public Vector2 Value; }
    [Game] public class MovementSpeed : IComponent { public float Value; }

    [Game] public class FaceToDirection : IComponent {  }

    [Game] public class RigidbodyMovement : IComponent {  }
    [Game] public class TransformMovement : IComponent {  }
    [Game] public class ForwardMovement : IComponent {  }
    [Game] public class ZigZagMovement : IComponent {  }

}
