using System.Collections.Generic;
using AbilityMadness.Code.Gameplay.Stats.Factory;
using Entitas;

namespace AbilityMadness.Code.Gameplay.Stats
{
    [Game] public class BaseStats : IComponent { public StatsData Value; }
    [Game] public class StatsModifiers : IComponent { public StatsData Value; }
    [Game] public class StatsChange : IComponent { public StatsTypeId Value; }

    [Game] public class StatsSetups : IComponent { public List<StatsSetup> Value; }

    [Game] public class StatsValue : IComponent { public float Value; }
}
