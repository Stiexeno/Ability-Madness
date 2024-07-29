using System.Collections.Generic;
using Entitas;

namespace AbilityMadness.Code.Gameplay.Input.Systems
{
    public class CleanupMouseTriggerSystem : ICleanupSystem
    {
        private readonly List<GameEntity> _buffer = new(32);
        private IGroup<GameEntity> _mouseTriggers;

        public CleanupMouseTriggerSystem(Contexts contexts)
        {
            _mouseTriggers = contexts.game.GetGroup(GameMatcher
                .AllOf(
                    GameMatcher.MouseCollision));
        }

        public void Cleanup()
        {
            foreach (var mouseTrigger in _mouseTriggers.GetEntities(_buffer))
            {
                mouseTrigger.Destroy();
            }
        }
    }
}
