using Entitas;
using UnityEngine;

namespace AbilityMadness.Code.Gameplay.Input
{
    [Game] public class AxisInput : IComponent { public Vector2 Value; }
    [Game] public class LookInput : IComponent { public Vector2 Value; }
}
