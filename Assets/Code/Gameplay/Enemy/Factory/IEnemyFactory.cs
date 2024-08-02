using UnityEngine;

namespace AbilityMadness.Code.Gameplay.Enemy.Factory
{
    public interface IEnemyFactory
    {
        GameEntity CreateRobot(Vector3 position);
    }
}
