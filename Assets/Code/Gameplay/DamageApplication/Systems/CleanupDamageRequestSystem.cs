using System.Collections.Generic;
using Entitas;

namespace AbilityMadness.Code.Gameplay.DamageApplication.Systems
{
    public class CleanupDamageRequestSystem : ICleanupSystem
    {
        private readonly List<GameEntity> _buffer = new(32);
        private IGroup<GameEntity> _entities;

        public CleanupDamageRequestSystem(GameContext gameContext)
        {
            _entities = gameContext.GetGroup(GameMatcher
                .AllOf(
                    GameMatcher.DamageRequest));
        }

        public void Cleanup()
        {
            foreach (var entity in _entities.GetEntities(_buffer))
            {
                entity.isDestructed = true;
            }
        }
    }
}
