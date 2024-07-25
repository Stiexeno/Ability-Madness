using Entitas;
using UnityEngine;

namespace AbilityMadness.Code.Gameplay.Camera.Systems
{
    public class SetCameraOffsetToFollowTargetSystem : IExecuteSystem
    {
        private IGroup<GameEntity> _cameras;
        private IGroup<GameEntity> _followTargets;

        public SetCameraOffsetToFollowTargetSystem(Contexts contexts)
        {
            _cameras = contexts.game.GetGroup(GameMatcher
                .AllOf(
                    GameMatcher.Camera,
                    GameMatcher.CameraOffset,
                    GameMatcher.FollowTargetId));

            _followTargets = contexts.game.GetGroup(GameMatcher
                .AllOf(
                    GameMatcher.Identifier,
                    GameMatcher.Player,
                    GameMatcher.WorldPosition));
        }

        public void Execute()
        {
            foreach (var camera in _cameras)
            foreach (var followTarget in _followTargets)
            {
                if (followTarget.Identifier.Equals(camera.FollowTargetId))
                {
                    var targetPosition = Vector3.Lerp(
                        camera.WorldPosition,
                        followTarget.WorldPosition,
                        Time.deltaTime);

                    targetPosition = new Vector3(targetPosition.x, targetPosition.y, -10f);
                    camera.WorldPosition = targetPosition;
                }
            }
        }
    }
}
