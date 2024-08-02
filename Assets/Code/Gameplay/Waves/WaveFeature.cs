using AbilityMadness.Code.Gameplay.Waves.Systems;
using AbilityMadness.Code.Infrastructure.Services.ECS;

namespace AbilityMadness.Code.Gameplay.Waves
{
    public class WaveFeature : Feature
    {
        public WaveFeature(ISystemFactory systemFactory)
        {
            Add(systemFactory.Create<SpawnEnemyWaveSystem>());
        }
    }
}
