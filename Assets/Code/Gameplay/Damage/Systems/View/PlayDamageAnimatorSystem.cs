using Entitas;

namespace AbilityMadness.Code.Gameplay.DamageApplication.Systems.View
{
    public class PlayDamageAnimatorSystem : IExecuteSystem
    {
        private IGroup<GameEntity> _damageReceivedEvents;
        private IGroup<GameEntity> _targets;
        private GameContext _gameContext;

        public PlayDamageAnimatorSystem(GameContext gameContext)
        {
            _gameContext = gameContext;
            _damageReceivedEvents = gameContext.GetGroup(GameMatcher
                .AllOf(
                    GameMatcher.EffectReceived,
                    GameMatcher.DamageEffect,
                    GameMatcher.TargetId));

            _targets = gameContext.GetGroup(GameMatcher
                .AllOf(
                    GameMatcher.DamageAnimator,
                    GameMatcher.Alive));
        }

        public void Execute()
        {
            foreach (var damageReceivedEvent in _damageReceivedEvents)
            {
                var target = _gameContext.GetEntityWithId(damageReceivedEvent.TargetId);

                if (_targets.ContainsEntity(target))
                {
                    target.DamageAnimator.PlayDamageAnimation();
                }
            }
        }
    }
}
