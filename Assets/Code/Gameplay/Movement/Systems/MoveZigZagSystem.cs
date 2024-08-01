using Entitas;
using UnityEngine;

namespace AbilityMadness.Code.Gameplay.Movement.Systems
{
    public class MoveZigZagSystem : IExecuteSystem
    {
        private const float frequency = 10f; // How often the zigzag direction changes
        private const float amplitude = 100f; // Maximum angle deviation for the zigzag

        private IGroup<GameEntity> _forwardEntities;

        public MoveZigZagSystem(Contexts contexts)
        {
            _forwardEntities = contexts.game.GetGroup(GameMatcher
                .AllOf(
                    GameMatcher.Direction,
                    GameMatcher.MovementSpeed,
                    GameMatcher.ZigZagMovement,
                    GameMatcher.ZigZagTimeElapsed,
                    GameMatcher.ZigZagTimeDirection));
        }

        public void Execute()
        {
            foreach (var forwardEntity in _forwardEntities)
            {
                forwardEntity.ZigZagTimeElapsed += Time.deltaTime;

                float zigzagAngle = Mathf.Sin(forwardEntity.ZigZagTimeElapsed * frequency) * amplitude;

                Vector3 newDirection = Quaternion.Euler(0, 0, zigzagAngle) * forwardEntity.ZigZagTimeDirection;

                newDirection = newDirection.normalized;

                forwardEntity.ReplaceDirection(newDirection);
            }
        }
    }
}
