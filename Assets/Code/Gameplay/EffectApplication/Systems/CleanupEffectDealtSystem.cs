using System.Collections.Generic;
using Entitas;

namespace AbilityMadness.Code.Gameplay.DamageApplication.Systems
{
    public class CleanupEffectDealtSystem : ICleanupSystem
    {
        private readonly List<GameEntity> _buffer = new(32);
        private IGroup<GameEntity> _entities;

        public CleanupEffectDealtSystem(GameContext gameContext)
        {
            _entities = gameContext.GetGroup(GameMatcher
                .AllOf(
                    GameMatcher.EffectDealt));
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
