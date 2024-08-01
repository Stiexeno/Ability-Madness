using System.Collections.Generic;
using Entitas;

namespace AbilityMadness.Code.Common.Cooldown.Systems
{
    public class CleanupCooldownUpSystem : ICleanupSystem
    {
        private readonly List<GameEntity> _buffer = new(32);
        private IGroup<GameEntity> _cooldownEntities;

        public CleanupCooldownUpSystem(GameContext gameContext)
        {
            _cooldownEntities = gameContext.GetGroup(GameMatcher
                .AllOf(
                    GameMatcher.CooldownUp));
        }

        public void Cleanup()
        {
            foreach (var cooldownEntity in _cooldownEntities.GetEntities(_buffer))
            {
                cooldownEntity.isCooldownUp = false;
            }
        }
    }
}
