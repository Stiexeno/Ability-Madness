using Entitas;

namespace AbilityMadness.Code.Gameplay.DamageApplication.Systems.View
{
    public class PlayDamageAnimatorSystem : IExecuteSystem
    {
        private IGroup<GameEntity> _damagedEntities;

        public PlayDamageAnimatorSystem(GameContext gameContext)
        {
            _damagedEntities = gameContext.GetGroup(GameMatcher
                .AllOf(
                    GameMatcher.DamageAnimator,
                    GameMatcher.DamageReceived,
                    GameMatcher.Alive));
        }

        public void Execute()
        {
            foreach (var damageAnimator in _damagedEntities)
            {
                damageAnimator.DamageAnimator.PlayDamageAnimation();
            }
        }
    }
}
