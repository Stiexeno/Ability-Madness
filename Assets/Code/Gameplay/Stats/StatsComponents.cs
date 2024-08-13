using Entitas;

namespace AbilityMadness.Code.Gameplay.Stats
{
    [Game] public class StatsChange : IComponent { public StatsTypeId Value; }

    [Game] public class StatsValue : IComponent { public float Value; }
}
