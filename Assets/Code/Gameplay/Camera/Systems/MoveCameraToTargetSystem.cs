using Entitas;
using UnityEngine;

namespace AbilityMadness.Code.Gameplay.Camera.Systems
{
    public class MoveCameraToTargetSystem : IExecuteSystem
    {
        private IGroup<GameEntity> _cameras;
        private IGroup<GameEntity> _followTargets;
        private Contexts _contexts;

        public MoveCameraToTargetSystem(Contexts contexts)
        {
            _contexts = contexts;
            _cameras = contexts.game.GetGroup(GameMatcher
                .AllOf(
                    GameMatcher.Camera,
                    GameMatcher.CameraOffset,
                    GameMatcher.FollowTargetId,
                    GameMatcher.CameraSmooth,
                    GameMatcher.Velocity));

            _followTargets = contexts.game.GetGroup(GameMatcher
                .AllOf(
                    GameMatcher.Id,
                    GameMatcher.Player,
                    GameMatcher.WorldPosition));
        }

        public void Execute()
        {
            foreach (var camera in _cameras)
            {
                var followTarget = _contexts.game.GetEntityWithId(camera.FollowTargetId);

                if (_followTargets.ContainsEntity(followTarget))
                {
                    var targetPosition = new Vector3(followTarget.WorldPosition.x, followTarget.WorldPosition.y, -10f);

                    var cameraVelocity = camera.Velocity;

                     camera.WorldPosition = Vector3.SmoothDamp(
                         camera.WorldPosition,
                         targetPosition,
                         ref cameraVelocity,
                         0.1f);

                     camera.Velocity = cameraVelocity;
                }
            }
        }
    }
}
