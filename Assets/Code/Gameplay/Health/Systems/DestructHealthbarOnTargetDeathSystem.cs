using System.Collections.Generic;
using Entitas;

namespace AbilityMadness.Code.Gameplay.Health.Systems
{
    public class DestructHealthbarOnTargetDeathSystem : IExecuteSystem
    {
        private readonly List<GameEntity> _buffer = new(32);

        private IGroup<GameEntity> _healthbarEntities;
        private IGroup<GameEntity> _ownerEntities;
        private GameContext _gameContext;

        public DestructHealthbarOnTargetDeathSystem(GameContext gameContext)
        {
            _gameContext = gameContext;
            _healthbarEntities = gameContext.GetGroup(GameMatcher
                .AllOf(
                    GameMatcher.Healthbar,
                    GameMatcher.TargetId));

            _ownerEntities = gameContext.GetGroup(GameMatcher
                .AllOf(
                    GameMatcher.Alive));
        }

        public void Execute()
        {
            foreach (var healthbar in _healthbarEntities.GetEntities(_buffer))
            {
                var owner = _gameContext.GetEntityWithId(healthbar.TargetId);

                if (_ownerEntities.ContainsEntity(owner) == false)
                {
                    healthbar.isDestructed = true;
                }
            }
        }
    }
}
