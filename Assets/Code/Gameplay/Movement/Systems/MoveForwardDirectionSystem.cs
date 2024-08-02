using AbilityMadness.Code.Extensions;
using Entitas;

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
                    GameMatcher.Alive));
        }

        public void Execute()
        {
            foreach (var forwardEntity in _forwardEntities)
            {
                forwardEntity.WorldPosition += forwardEntity.Direction.ToVector3() * forwardEntity.MovementSpeed;
            }
        }
    }
}
