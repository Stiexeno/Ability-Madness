using Entitas;

namespace AbilityMadness.Code.Gameplay.Status.Systems
{
    public class CleanupStatusRequestsSystem : ICleanupSystem
    {
        private IGroup<GameEntity> _requests;

        public CleanupStatusRequestsSystem(GameContext gameContext)
        {
            _requests = gameContext.GetGroup(GameMatcher
                .AllOf(
                    GameMatcher.StatusRequest));
        }

        public void Cleanup()
        {
            foreach (var request in _requests)
            {
                request.isDestructed = true;
            }
        }
    }
}
