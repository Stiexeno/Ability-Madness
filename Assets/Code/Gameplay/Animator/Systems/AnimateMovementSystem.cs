using Entitas;

namespace AbilityMadness.Code.Gameplay.Animator.Systems
{
    public class AnimateMovementSystem : IExecuteSystem
    {
        private IGroup<GameEntity> _entities;

        public AnimateMovementSystem(GameContext gameContext)
        {
            _entities = gameContext.GetGroup(GameMatcher
                .AllOf(
                    GameMatcher.MovementAnimator,
                    GameMatcher.LookDirection,
                    GameMatcher.Velocity,
                    GameMatcher.Alive));
        }

        public void Execute()
        {
            foreach (var entity in _entities)
            {
                if (entity.Velocity.magnitude > 0f)
                {
                    entity.MovementAnimator.SetWalk(entity.Velocity);
                }
                else
                {
                    entity.MovementAnimator.SetIdle(entity.Velocity);
                }
            }
        }
    }
}
