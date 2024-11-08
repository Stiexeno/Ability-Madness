using AbilityMadness.Code.Gameplay.Enemy.Waves.Systems;
using AbilityMadness.Code.Infrastructure.ECS;

namespace AbilityMadness.Code.Gameplay.Enemy.Waves
{
    public class WaveFeature : Feature
    {
        public WaveFeature(ISystemFactory systemFactory)
        {
            Add(systemFactory.Create<SpawnEnemyWaveSystem>());
        }
    }
}
