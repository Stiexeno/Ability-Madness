using Entitas;

namespace AbilityMadness.Code.Gameplay.DamageApplication.View
{
    public class PlayDamageAnimatorSystem : IExecuteSystem
    {
        private IGroup<GameEntity> _damageAnimators;

        public PlayDamageAnimatorSystem(GameContext gameContext)
        {
            _damageAnimators = gameContext.GetGroup(GameMatcher
                .AllOf(
                    GameMatcher.DamageAnimator,
                    GameMatcher.DamageReceived));
        }

        public void Execute()
        {
            foreach (var damageAnimator in _damageAnimators)
            {
                damageAnimator.DamageAnimator.PlayDamageAnimation();
            }
        }
    }
}
