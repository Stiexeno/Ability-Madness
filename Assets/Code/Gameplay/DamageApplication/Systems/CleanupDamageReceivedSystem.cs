using System.Collections.Generic;
using Entitas;

namespace AbilityMadness.Code.Gameplay.DamageApplication.Systems
{
    public class CleanupDamageReceivedSystem : ICleanupSystem
    {
        private readonly List<GameEntity> _buffer = new(32);
        private IGroup<GameEntity> _damageReceivedEntities;

        public CleanupDamageReceivedSystem(GameContext gameContext)
        {
            _damageReceivedEntities = gameContext.GetGroup(GameMatcher
                .AllOf(
                    GameMatcher.DamageReceived));
        }

        public void Cleanup()
        {
            foreach (var damageReceivedEntity in _damageReceivedEntities.GetEntities(_buffer))
            {
                damageReceivedEntity.RemoveDamageReceived();
            }
        }
    }
}
