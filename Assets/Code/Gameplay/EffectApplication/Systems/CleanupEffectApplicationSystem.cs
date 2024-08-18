using System.Collections.Generic;
using Entitas;

namespace AbilityMadness.Code.Gameplay.DamageApplication.Systems
{
    public class CleanupEffectApplicationSystem : ICleanupSystem
    {
        private readonly List<GameEntity> _buffer = new(32);
        private IGroup<GameEntity> _entities;

        public CleanupEffectApplicationSystem(GameContext gameContext)
        {
            _entities = gameContext.GetGroup(GameMatcher
                .AllOf(
                    GameMatcher.EffectApplication));
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
