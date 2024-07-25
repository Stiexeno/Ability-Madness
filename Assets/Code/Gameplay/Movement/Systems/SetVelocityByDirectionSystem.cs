using Entitas;

namespace AbilityMadness.Code.Gameplay.Movement.Systems
{
    public class SetVelocityByDirectionSystem : IExecuteSystem
    {
        private IGroup<GameEntity> _entities;

        public SetVelocityByDirectionSystem(Contexts contexts)
        {
            _entities = contexts.game.GetGroup(GameMatcher
                .AllOf(
                    GameMatcher.Direction,
                    GameMatcher.Velocity,
                    GameMatcher.MovementSpeed));
        }

        public void Execute()
        {
            foreach (var entity in _entities)
            {
                entity.Velocity = entity.Direction.normalized * entity.MovementSpeed;
            }
        }
    }
}
