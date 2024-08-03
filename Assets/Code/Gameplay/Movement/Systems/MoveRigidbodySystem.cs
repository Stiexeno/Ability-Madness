using Entitas;

namespace AbilityMadness.Code.Gameplay.Movement.Systems
{
    public class MoveRigidbodySystem : IExecuteSystem
    {
        private IGroup<GameEntity> _entities;

        public MoveRigidbodySystem(Contexts contexts)
        {
            _entities = contexts.game.GetGroup(GameMatcher
                .AllOf(
                    GameMatcher.Velocity,
                    GameMatcher.Rigidbody2D)
                .NoneOf(
                    GameMatcher.Dashing));
        }

        public void Execute()
        {
            foreach (var entity in _entities)
            {
                entity.Rigidbody2D.velocity = entity.Velocity;
            }
        }
    }
}
