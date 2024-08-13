using System.Collections.Generic;
using Entitas;

namespace AbilityMadness.Code.Gameplay.Experience.Systems
{
    public class CleanupLevelUpSystem : ICleanupSystem
    {
        private readonly List<GameEntity> _buffer = new(32);
        private IGroup<GameEntity> _entities;

        public CleanupLevelUpSystem(GameContext gameContext)
        {
            _entities = gameContext.GetGroup(GameMatcher
                .AllOf(
                    GameMatcher.LevelUp));
        }

        public void Cleanup()
        {
            foreach (var entity in _entities.GetEntities(_buffer))
            {
                entity.isLevelUp = false;
            }
        }
    }
}
