using System.Collections.Generic;
using Entitas;

namespace AbilityMadness.Code.Gameplay.Health.Systems
{
    public class MarkLifeStateSystem : IExecuteSystem
    {
        private readonly List<GameEntity> _buffer = new(32);
        private IGroup<GameEntity> _healthEntities;

        public MarkLifeStateSystem(GameContext gameContext)
        {
            _healthEntities = gameContext.GetGroup(GameMatcher
                .AllOf(
                    GameMatcher.Health)
                .NoneOf(
                    GameMatcher.Dead));
        }

        public void Execute()
        {
            foreach (var entity in _healthEntities.GetEntities(_buffer))
            {
                entity.isAlive = entity.Health > 0;
                entity.isDead = entity.Health <= 0;
                entity.isProccessingDeath = entity.isDead;
            }
        }
    }
}
