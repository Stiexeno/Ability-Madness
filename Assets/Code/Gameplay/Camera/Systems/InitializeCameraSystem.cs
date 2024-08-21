using AbilityMadness.Code.Gameplay.Camera.Factory;
using Entitas;

namespace AbilityMadness.Code.Gameplay.Camera.Systems
{
    public class InitializeCameraSystem : IInitializeSystem
    {
        private readonly IGroup<GameEntity> _cameras;
        private IGroup<GameEntity> _players;

        public InitializeCameraSystem(GameContext gameContext, ICameraFactory cameraFactory)
        {
            cameraFactory.CreateCamera();

            _cameras = gameContext.GetGroup(GameMatcher
                .AllOf(
                    GameMatcher.Camera,
                    GameMatcher.FollowTargetId));

            _players = gameContext.GetGroup(GameMatcher
                .AllOf(
                    GameMatcher.Player));
        }

        public void Initialize()
        {
            foreach (var camera in _cameras)
            foreach (var player in _players)
            {
                camera.FollowTargetId = player.Id;
            }
        }
    }
}
