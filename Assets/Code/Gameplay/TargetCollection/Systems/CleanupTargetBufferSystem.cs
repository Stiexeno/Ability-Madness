using Entitas;

namespace AbilityMadness.Code.Gameplay.TargetCollection.Systems
{
    public class CleanupTargetBufferSystem : ICleanupSystem
    {
        private IGroup<GameEntity> _targetBuffers;

        public CleanupTargetBufferSystem(Contexts contexts)
        {
            _targetBuffers = contexts.game.GetGroup(GameMatcher
                .AllOf(
                    GameMatcher.TargetBuffer));
        }

        public void Cleanup()
        {
            foreach (var targetBuffer in _targetBuffers)
            {
                targetBuffer.TargetBuffer.Clear();
            }
        }
    }
}
