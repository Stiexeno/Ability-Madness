using System.Collections.Generic;
using AbilityMadness.Code.Gameplay.Lifetime;
using Entitas;

namespace AbilityMadness.Code.Gameplay.Health.Systems
{
    public class PlayDeathAnimationSystem : IExecuteSystem
    {
        private readonly List<GameEntity> _buffer = new(32);
        private IGroup<GameEntity> _deadEntties;

        public PlayDeathAnimationSystem(GameContext gameContext)
        {
            _deadEntties = gameContext.GetGroup(GameMatcher
                .AllOf(
                    GameMatcher.Dead,
                    GameMatcher.DeathAnimator,
                    GameMatcher.ProccessingDeath));
        }

        public void Execute()
        {
            foreach (var deadEntity in _deadEntties.GetEntities(_buffer))
            {
                deadEntity.DeathAnimator.PlayDeath();

                var deadAnimationLength = deadEntity.DeathAnimator.GetDeathAnimationLength();
                deadEntity.SetLifetime(deadAnimationLength);
            }
        }
    }
}
