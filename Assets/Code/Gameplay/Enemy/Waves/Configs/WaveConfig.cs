using UnityEngine;

namespace AbilityMadness.Code.Gameplay.Enemy.Waves.Configs
{
    [CreateAssetMenu(fileName = nameof(WaveConfig), menuName = Constants.Root + "/Configs/WaveConfig")]
    public class WaveConfig : ScriptableObject
    {
        public EnemyTypeId enemyType;
        public int maxSpawnedEnemies = 1;

        public int spawnAmount = 1;
        public float spawnInterval = 3;

        public int startTime = 0;
        public int endTime = 0;
    }
}
