using AbilityMadness.Code.Common;
using AbilityMadness.Code.Extensions;
using AbilityMadness.Code.Gameplay.Enemy.Waves.Configs;
using AbilityMadness.Code.Infrastructure.Configs;
using AbilityMadness.Code.Infrastructure.Identifiers;

namespace AbilityMadness.Code.Gameplay.Enemy.Waves.Factory
{
    public class WaveFactory : IWaveFactory
    {
        private IIdentifierService _identifierService;
        private IConfigsService _configsService;

        public WaveFactory(IIdentifierService identifierService, IConfigsService configsService)
        {
            _configsService = configsService;
            _identifierService = identifierService;
        }

        public void CreateWaves()
        {
            var waveConfigs = _configsService.WaveConfigs;

            foreach (var waveConfig in waveConfigs)
            {
                CreateWave(waveConfig);
            }
        }

        private GameEntity CreateWave(WaveConfig waveConfig)
        {
            return CreateEntity.Empty()
                .AddId(_identifierService.Next())
                .With(x => x.isWave = true)
                .AddEnemyTypeId(waveConfig.enemyType)
                .AddTimeElapsed(0f)
                .AddMaxSpawnedEnemies(waveConfig.maxSpawnedEnemies)
                .AddSpawnedEnemies(0)
                .AddSpawnAmount(waveConfig.spawnAmount)
                .AddSpawnInterval(waveConfig.spawnInterval)
                .AddStartTime(waveConfig.startTime)
                .AddEndTime(waveConfig.endTime);
        }
    }
}
