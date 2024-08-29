using AbilityMadness.Code.Gameplay.Projectile.Systems.Throwable.Behaviours;
using Entitas;
using UnityEngine;

namespace AbilityMadness.Code.Gameplay.Projectile.Throwable
{
    // Throwable
    [Game] public class Throwable : IComponent { }
    [Game] public class ThrowableAnimatorComponent : IComponent { public ThrowableAnimator Value; }

    [Game] public class MaxHeight : IComponent { public float Value; }
    [Game] public class StartPosition : IComponent { public Vector3 Value; }
    [Game] public class TargetPosition : IComponent { public Vector3 Value; }
}
