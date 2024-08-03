using Entitas;

namespace AbilityMadness.Code.Gameplay.Movement.Systems
{
    public class ResetVelocityOnDeathSystem : IExecuteSystem
    {
        private IGroup<GameEntity> _entities;

        public ResetVelocityOnDeathSystem(Contexts contexts)
        {
            _entities = contexts.game.GetGroup(GameMatcher
                .AllOf(
                    GameMatcher.Velocity,
                    GameMatcher.Dead));
        }

        public void Execute()
        {
            foreach (var entity in _entities)
            {
                entity.Velocity = UnityEngine.Vector2.zero;
            }
        }
    }
}
