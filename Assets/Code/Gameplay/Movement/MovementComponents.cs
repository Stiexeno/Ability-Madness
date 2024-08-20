using Entitas;
using UnityEngine;

namespace AbilityMadness.Code.Gameplay.Movement
{
    [Game] public class Direction : IComponent { public Vector2 Value; }
    [Game] public class LookDirection : IComponent { public Vector2 Value; }
    [Game] public class MovementSpeed : IComponent { public float Value; }

    [Game] public class Dashing : IComponent {  }
    [Game] public class DashCooldown : IComponent { public float Value; }
    [Game] public class DashDuration : IComponent { public float Value; }
    [Game] public class RequestDash : IComponent { }

    [Game] public class FaceToDirection : IComponent {  }

    [Game] public class RigidbodyMovement : IComponent {  }
    [Game] public class TransformMovement : IComponent {  }
    [Game] public class ForwardMovement : IComponent {  }
    [Game] public class ZigZagMovement : IComponent {  }
    [Game] public class FollowMovement : IComponent {  }

    [Game] public class DistanceTraveled : IComponent { public float Value; }
    [Game] public class LastPosition : IComponent { public Vector3 Value; }

}
