using Entitas;
using UnityEngine;

namespace AbilityMadness.Code.Gameplay.Camera
{
    [Game]public class Camera : IComponent { }
    [Game]public class FollowTargetId : IComponent { public int Value; }
    [Game]public class CameraOffset : IComponent { public Vector2 Value; }

    [Game]public class CameraSmooth : IComponent { public float Value; }
}
