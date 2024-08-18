using AbilityMadness.Code.Gameplay.DamageApplication.Factory;
using Entitas;

namespace AbilityMadness.Code.Gameplay.DamageApplication.Systems
{
    public class CreateDamageRequestOnTargetBufferSystem : IExecuteSystem
    {
        private IGroup<GameEntity> _damageApplicators;
        private GameContext _gameContext;
        private IGroup<GameEntity> _targets;
        private IDamageFactory _damageFactory;

        public CreateDamageRequestOnTargetBufferSystem(GameContext gameContext, IDamageFactory damageFactory)
        {
            _damageFactory = damageFactory;
            _gameContext = gameContext;
            _damageApplicators = gameContext.GetGroup(GameMatcher
                .AllOf(
                    GameMatcher.TargetBuffer,
                    GameMatcher.Damage,
                    GameMatcher.Team,
                    GameMatcher.Alive));

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
                    var id = damageApplicator.hasProducerId ? damageApplicator.ProducerId : damageApplicator.Id;
                    _damageFactory.CreateDamageRequest(id, targetId, damageApplicator.Damage);
                }
            }
        }
    }
}
