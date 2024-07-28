using Entitas;

namespace AbilityMadness.Code.Gameplay.Movement.Systems
{
    public class SetVelocityToRigidbodySystem : IExecuteSystem
    {
        private IGroup<GameEntity> _entities;

        public SetVelocityToRigidbodySystem(Contexts contexts)
        {
            _entities = contexts.game.GetGroup(GameMatcher
                .AllOf(
                    GameMatcher.Velocity,
                    GameMatcher.Rigidbody2D));
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
