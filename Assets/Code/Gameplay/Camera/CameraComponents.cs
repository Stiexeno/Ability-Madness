﻿using Entitas;
using UnityEngine;

namespace AbilityMadness.Code.Gameplay.Camera
{
    public class Camera : IComponent { }
    public class FollowTargetId : IComponent { public int Value; }
    public class CameraOffset : IComponent { public Vector2 Value; }
}
