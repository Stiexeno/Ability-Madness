using Entitas;

namespace AbilityMadness.Code.Gameplay.Enemy.Waves
{
    [Game] public class Wave : IComponent { }

    [Game] public class SpawnedEnemies : IComponent { public int Value; }
    [Game] public class MaxSpawnedEnemies : IComponent { public int Value; }

    [Game] public class SpawnInterval : IComponent { public float Value; }

    [Game] public class StartTime : IComponent { public int Value; }
    [Game] public class EndTime : IComponent { public int Value; }
}
