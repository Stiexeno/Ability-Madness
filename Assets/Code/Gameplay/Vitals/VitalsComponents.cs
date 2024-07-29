using Entitas;

namespace AbilityMadness.Code.Gameplay.Vitals
{
    [Game] public class Water : IComponent { public float Value; }
    [Game] public class MaxWater : IComponent { public float Value; }

    [Game] public class Food : IComponent { public float Value; }
    [Game] public class MaxFood : IComponent { public float Value; }

    [Game] public class Health : IComponent { public float Value; }
    [Game] public class MaxHealth : IComponent { public float Value; }
}
