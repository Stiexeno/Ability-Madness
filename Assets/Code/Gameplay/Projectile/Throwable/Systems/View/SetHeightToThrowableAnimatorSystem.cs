using Entitas;
using UnityEngine;

namespace AbilityMadness.Code.Gameplay.Projectile.Systems.Implementations.View
{
    public class SetHeightToThrowableAnimatorSystem : IExecuteSystem
    {
        private IGroup<GameEntity> _throwables;

        public SetHeightToThrowableAnimatorSystem(GameContext gameContext)
        {
            _throwables = gameContext.GetGroup(GameMatcher
                .AllOf(
                    GameMatcher.Throwable,
                    GameMatcher.StartPosition,
                    GameMatcher.StartPosition,
                    GameMatcher.ThrowableAnimator,
                    GameMatcher.WorldPosition,
                    GameMatcher.MaxHeight));
        }

        public void Execute()
        {
            foreach (var throwable in _throwables)
            {
                var distanceBetweenRange = Vector3.Distance(throwable.StartPosition, throwable.TargetPosition);
                var distance = Vector3.Distance(throwable.TargetPosition, throwable.WorldPosition);
                var normalizedDistance = distance / distanceBetweenRange;

                throwable.ThrowableAnimator.SetHeight(normalizedDistance, throwable.MaxHeight);
            }
        }
    }
}
