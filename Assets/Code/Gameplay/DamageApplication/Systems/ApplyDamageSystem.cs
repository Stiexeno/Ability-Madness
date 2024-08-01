using Entitas;

namespace AbilityMadness.Code.Gameplay.DamageApplication.Systems
{
    public class ApplyDamageSystem : IExecuteSystem
    {
        private IGroup<GameEntity> _damageApplicators;
        private GameContext _gameContext;

        public ApplyDamageSystem(GameContext gameContext)
        {
            _gameContext = gameContext;
            _damageApplicators = gameContext.GetGroup(GameMatcher
                .AllOf(
                    GameMatcher.TargetBuffer,
                    GameMatcher.Damage));
        }

        public void Execute()
        {
            foreach (var damageApplicator in _damageApplicators)
            foreach (var targetId in damageApplicator.TargetBuffer)
            {
                var entity = _gameContext.GetEntityWithId(targetId);
                entity.ReplaceDamageReceived(damageApplicator.Damage);
            }
        }
    }
}
