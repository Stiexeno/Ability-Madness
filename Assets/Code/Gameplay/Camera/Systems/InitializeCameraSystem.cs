using AbilityMadness.Code.Gameplay.Camera.Factory;
using Entitas;

namespace AbilityMadness.Code.Gameplay.Camera.Systems
{
    public class InitializeCameraSystem : IInitializeSystem
    {
        private readonly IGroup<GameEntity> _cameras;
        private IGroup<GameEntity> _players;

        public InitializeCameraSystem(Contexts contexts, ICameraFactory cameraFactory)
        {
            cameraFactory.CreateCamera();

            _cameras = contexts.game.GetGroup(GameMatcher
                .AllOf(GameMatcher.Camera));

            _players = contexts.game.GetGroup(GameMatcher
                .AllOf(GameMatcher.Player));
        }

        public void Initialize()
        {
            foreach (var camera in _cameras)
            foreach (var player in _players)
            {
                camera.FollowTargetId = player.Identifier;
            }
        }
    }
}
