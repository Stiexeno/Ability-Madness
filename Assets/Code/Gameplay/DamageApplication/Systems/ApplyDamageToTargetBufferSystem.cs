using Entitas;

namespace AbilityMadness.Code.Gameplay.DamageApplication.Systems
{
    public class ApplyDamageToTargetBufferSystem : IExecuteSystem
    {
        private IGroup<GameEntity> _damageApplicators;
        private GameContext _gameContext;
        private IGroup<GameEntity> _targets;

        public ApplyDamageToTargetBufferSystem(GameContext gameContext)
        {
            _gameContext = gameContext;
            _damageApplicators = gameContext.GetGroup(GameMatcher
                .AllOf(
                    GameMatcher.TargetBuffer,
                    GameMatcher.Damage,
                    GameMatcher.Team));

            _targets = gameContext.GetGroup(GameMatcher
                .AllOf(
                    GameMatcher.Team,
                    GameMatcher.Health,
                    GameMatcher.Alive));
        }

        public void Execute()
        {
            foreach (var damageApplicator in _damageApplicators)
            foreach (var targetId in damageApplicator.TargetBuffer)
            {
                var entity = _gameContext.GetEntityWithId(targetId);

                if (_targets.ContainsEntity(entity) && entity.Team != damageApplicator.Team)
                {
                    entity.Health -= damageApplicator.Damage;
                    entity.ReplaceDamageReceived(damageApplicator.Damage);
                }
            }
        }
    }
}
