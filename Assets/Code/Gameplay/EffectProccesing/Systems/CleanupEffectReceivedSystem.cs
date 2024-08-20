using System.Collections.Generic;
using Entitas;

namespace AbilityMadness.Code.Gameplay.EffectProccesing.Systems
{
    public class CleanupEffectReceivedSystem : ICleanupSystem
    {
        private readonly List<GameEntity> _buffer = new(32);
        private IGroup<GameEntity> _entities;

        public CleanupEffectReceivedSystem(GameContext gameContext)
        {
            _entities = gameContext.GetGroup(GameMatcher
                .AllOf(
                    GameMatcher.EffectReceived));
        }

        public void Cleanup()
        {
            foreach (var entity in _entities.GetEntities(_buffer))
            {
                entity.Destroy();
            }
        }
    }
}
