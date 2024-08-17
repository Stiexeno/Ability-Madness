using AbilityMadness.Code.Extensions;
using Entitas;
using UnityEngine;

namespace AbilityMadness.Code.Gameplay.Movement.Systems
{
    public class MoveForwardDirectionSystem : IExecuteSystem
    {
        private IGroup<GameEntity> _forwardEntities;

        public MoveForwardDirectionSystem(Contexts contexts)
        {
            _forwardEntities = contexts.game.GetGroup(GameMatcher
                .AllOf(
                    GameMatcher.Direction,
                    GameMatcher.WorldPosition,
                    GameMatcher.MovementSpeed,
                    GameMatcher.ForwardMovement,
                    GameMatcher.Alive,
                    GameMatcher.TransformMovement));
        }

        public void Execute()
        {
            foreach (var forwardEntity in _forwardEntities)
            {
                forwardEntity.WorldPosition += forwardEntity.Direction.ToVector3() * forwardEntity.MovementSpeed * Time.deltaTime;
            }
        }
    }
}
