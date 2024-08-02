using Entitas;
using UnityEngine;

namespace AbilityMadness.Code.Gameplay.Movement.Systems
{
    public class MoveZigZagSystem : IExecuteSystem
    {
        private const float frequency = 10f;
        private const float amplitude = 100f;

        private IGroup<GameEntity> _forwardEntities;

        public MoveZigZagSystem(Contexts contexts)
        {
            _forwardEntities = contexts.game.GetGroup(GameMatcher
                .AllOf(
                    GameMatcher.Direction,
                    GameMatcher.MovementSpeed,
                    GameMatcher.ZigZagMovement,
                    GameMatcher.ZigZagTimeElapsed,
                    GameMatcher.ZigZagDirection));
        }

        public void Execute()
        {
            foreach (var forwardEntity in _forwardEntities)
            {
                forwardEntity.ZigZagTimeElapsed += Time.deltaTime;

                float zigzagAngle = Mathf.Sin((frequency / 2f) - forwardEntity.ZigZagTimeElapsed * frequency) * amplitude;

                Vector3 newDirection = Quaternion.Euler(0, 0, zigzagAngle) * forwardEntity.ZigZagDirection;

                newDirection = newDirection.normalized;

                forwardEntity.ReplaceDirection(newDirection);
            }
        }
    }
}
