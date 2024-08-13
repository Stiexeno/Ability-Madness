using AbilityMadness.Code.Gameplay.Stats;
using AbilityMadness.Code.Gameplay.Stats.Factory;
using Entitas;

namespace AbilityMadness.Code.Gameplay.DamageApplication.OnDamageDealt.Systems
{
    public class HealOnDamageDealtSystem : IExecuteSystem
    {
        private IGroup<GameEntity> _entities;
        private IGroup<GameEntity> _owners;
        private GameContext _gameContext;
        private IStatsFactory _statsFactory;

        public HealOnDamageDealtSystem(GameContext gameContext, IStatsFactory statsFactory)
        {
            _statsFactory = statsFactory;
            _gameContext = gameContext;
            _entities = gameContext.GetGroup(GameMatcher
                .AllOf(
                    GameMatcher.DamageDealt,
                    GameMatcher.LifeSteal,
                    GameMatcher.Team,
                    GameMatcher.OwnerId));

            _owners = gameContext.GetGroup(GameMatcher
                .AllOf(
                    GameMatcher.Team,
                    GameMatcher.Id));
        }

        public void Execute()
        {
            foreach (var entity in _entities)
            {
                var owner = _gameContext.GetEntityWithId(entity.OwnerId);

                if (_owners.ContainsEntity(owner))
                {
                    _statsFactory.CreateStatsChange(StatsTypeId.Health, owner.Id, owner.Id, entity.LifeSteal);
                }
            }
        }
    }
}
