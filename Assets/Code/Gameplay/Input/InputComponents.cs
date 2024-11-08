﻿using Entitas;
using UnityEngine;

namespace AbilityMadness.Code.Gameplay.Input
{
    [Game] public class Input : IComponent {  }
    [Game] public class AxisInput : IComponent { public Vector2 Value; }
    [Game] public class LookInput : IComponent { public Vector2 Value; }
    [Game] public class MousePosition : IComponent { public Vector2 Value; }

    [Game] public class AttackPressed : IComponent {  }
    [Game] public class DashPressed : IComponent {  }

    [Game] public class MouseInHover : IComponent {  }

    [Game] public class MouseCollision : IComponent {  }
}
