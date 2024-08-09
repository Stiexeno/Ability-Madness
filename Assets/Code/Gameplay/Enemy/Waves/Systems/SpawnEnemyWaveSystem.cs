using AbilityMadness.Code.Extensions;
using AbilityMadness.Code.Gameplay.Enemy.Factory;
using AbilityMadness.Code.Gameplay.Weapons.Factory;
using Entitas;

namespace AbilityMadness.Code.Gameplay.Enemy.Waves.Systems
{
    public class SpawnEnemyWaveSystem : IExecuteSystem
    {
        private IGroup<GameEntity> _waves;
        private IEnemyFactory _enemyFactory;
        private IWeaponFactory _weaponFactory;

        public SpawnEnemyWaveSystem(
            GameContext gameContext,
            IEnemyFactory enemyFactory,
            IWeaponFactory weaponFactory)
        {
            _weaponFactory = weaponFactory;
            _enemyFactory = enemyFactory;
            _waves = gameContext.GetGroup(GameMatcher
                .AllOf(
                    GameMatcher.Wave,
                    GameMatcher.TimeElapsed,
                    GameMatcher.Interval));
        }

        public void Execute()
        {
            foreach (var wave in _waves)
            {
                if (wave.TimeElapsed <= wave.Interval)
                    continue;

                wave.TimeElapsed = 0;

                for (int i = 0; i < 3; i++)
                {
                    var position = CameraExtensions.GetRandomPositionOutsideScreen(5f);
                    var enemy = _enemyFactory.CreateRobot(position);
                }
            }
        }
    }
}
