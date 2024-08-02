using System.Collections.Generic;
using Entitas;

namespace AbilityMadness.Code.Gameplay.Health.Systems
{
    public class SetDeadOnHealthDepletedSystem : ICleanupSystem
    {
        private readonly List<GameEntity> _buffer = new(32);
        private IGroup<GameEntity> _healthEntities;

        public SetDeadOnHealthDepletedSystem(GameContext gameContext)
        {
            _healthEntities = gameContext.GetGroup(GameMatcher
                .AllOf(
                    GameMatcher.Alive,
                    GameMatcher.Health));
        }

        public void Cleanup()
        {
            foreach (var healthEntity in _healthEntities.GetEntities(_buffer))
            {
                if (healthEntity.Health <= 0)
                {
                    healthEntity.isAlive = false;
                    healthEntity.isDead = true;
                }
            }
        }
    }
}
