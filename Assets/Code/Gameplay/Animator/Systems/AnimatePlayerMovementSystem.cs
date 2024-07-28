using Entitas;

namespace AbilityMadness.Code.Gameplay.Animator.Systems
{
    public class AnimatePlayerMovementSystem : IExecuteSystem
    {
        private IGroup<GameEntity> _entities;

        public AnimatePlayerMovementSystem(Contexts contexts)
        {
            _entities = contexts.game.GetGroup(GameMatcher
                .AllOf(
                    GameMatcher.MovementAnimator,
                    GameMatcher.LookDirection,
                    GameMatcher.Velocity));
        }

        public void Execute()
        {
            foreach (var entity in _entities)
            {
                if (entity.Velocity.magnitude > 0f)
                {
                    entity.MovementAnimator.SetWalk(entity.LookDirection);
                }
                else
                {
                    entity.MovementAnimator.SetIdle(entity.LookDirection);
                }
            }
        }
    }
}
