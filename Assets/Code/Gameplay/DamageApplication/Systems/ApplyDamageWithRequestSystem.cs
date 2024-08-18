using AbilityMadness.Code.Gameplay.DamageApplication.Factory;
using Entitas;

namespace AbilityMadness.Code.Gameplay.DamageApplication.Systems
{
    public class ApplyDamageWithRequestSystem : IExecuteSystem
    {
        private IGroup<GameEntity> _damageRequests;
        private IGroup<GameEntity> _targets;
        private GameContext _gameContext;
        private IDamageFactory _damageFactory;

        public ApplyDamageWithRequestSystem(GameContext gameContext, IDamageFactory damageFactory)
        {
            _damageFactory = damageFactory;
            _gameContext = gameContext;
            _damageRequests = gameContext.GetGroup(GameMatcher
                .AllOf(
                    GameMatcher.DamageRequest,
                    GameMatcher.Damage,
                    GameMatcher.ProducerId,
                    GameMatcher.TargetId));

            _targets = gameContext.GetGroup(GameMatcher
                .AllOf(
                    GameMatcher.Team,
                    GameMatcher.Health,
                    GameMatcher.Alive));
        }

        public void Execute()
        {
            foreach (var damageRequest in _damageRequests)
            {
                var target = _gameContext.GetEntityWithId(damageRequest.TargetId);
                var producer = _gameContext.GetEntityWithId(damageRequest.ProducerId);

                if (_targets.ContainsEntity(target) && target.Team != producer.Team)
                {
                    target.Health -= damageRequest.Damage;
                    _damageFactory.CreateDamageReceived(damageRequest.ProducerId, target.Id, damageRequest.Damage);
                    _damageFactory.CreateDamageDealt(producer.Id, producer.Id, damageRequest.Damage);
                }
            }
        }
    }
}
