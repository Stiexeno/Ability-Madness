using AbilityMadness.Code.Extensions;
using AbilityMadness.Code.Gameplay.Enemy.Factory;
using Entitas;

namespace AbilityMadness.Code.Gameplay.Enemy.Waves.Systems
{
    public class SpawnEnemyWaveSystem : IExecuteSystem
    {
        private IGroup<GameEntity> _waves;
        private IEnemyFactory _enemyFactory;
        private IGroup<GameEntity> _rounds;

        public SpawnEnemyWaveSystem(
            GameContext gameContext,
            IEnemyFactory enemyFactory)
        {
            _enemyFactory = enemyFactory;
            _waves = gameContext.GetGroup(GameMatcher
                .AllOf(
                    GameMatcher.Wave,
                    GameMatcher.TimeElapsed,
                    GameMatcher.SpawnInterval,
                    GameMatcher.StartTime,
                    GameMatcher.EndTime,
                    GameMatcher.SpawnAmount,
                    GameMatcher.MaxSpawnedEnemies,
                    GameMatcher.SpawnedEnemies));

            _rounds = gameContext.GetGroup(GameMatcher
                .AllOf(
                    GameMatcher.RoundTime,
                    GameMatcher.TimeElapsed));
        }

        public void Execute()
        {
            foreach (var wave in _waves)
            {
                foreach (var round in _rounds)
                {
                    if (wave.StartTime >= round.TimeElapsed ||
                        wave.EndTime < round.TimeElapsed ||
                        wave.SpawnedEnemies >= wave.MaxSpawnedEnemies ||
                        wave.TimeElapsed <= wave.SpawnInterval)
                        continue;

                    wave.TimeElapsed = 0;

                    for (int i = 0; i < wave.SpawnAmount; i++)
                    {
                        var position = CameraExtensions.GetRandomPositionOutsideScreen(5f);
                        _enemyFactory.CreateRobot(position);

                        wave.SpawnedEnemies++;
                    }
                }
            }
        }
    }
}
