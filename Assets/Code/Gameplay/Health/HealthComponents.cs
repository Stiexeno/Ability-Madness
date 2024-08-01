using Entitas;

namespace AbilityMadness.Code.Gameplay.Health
{
    [Game] public class Health : IComponent { public int Value; }
    [Game] public class MaxHealth : IComponent { public int Value; }

    [Game] public class TeamComponent : IComponent { public Team Value; }
}
