using System.Collections.Generic;
using Entitas;

namespace AbilityMadness.Code.Gameplay.Status.Systems
{
    public class ResetExistingStatusDurationSystem : IExecuteSystem
    {
        private readonly List<GameEntity> _buffer = new(32);
        private IGroup<GameEntity> _requests;
        private IGroup<GameEntity> _existingStatuses;

        public ResetExistingStatusDurationSystem(GameContext gameContext)
        {
            _requests = gameContext.GetGroup(GameMatcher
                .AllOf(
                    GameMatcher.StatusRequest,
                    GameMatcher.TargetId,
                    GameMatcher.ProducerId,
                    GameMatcher.StatusSetup));

            _existingStatuses = gameContext.GetGroup(GameMatcher
                .AllOf(
                    GameMatcher.Status,
                    GameMatcher.TargetId,
                    GameMatcher.TimeLeft,
                    GameMatcher.Duration));
        }

        public void Execute()
        {
            foreach (var request in _requests.GetEntities(_buffer))
            {
                foreach (var existingStatus in _existingStatuses)
                {
                    if (request.TargetId == existingStatus.TargetId &&
                        request.StatusSetup.type == existingStatus.StatusTypeId)
                    {
                        existingStatus.TimeLeft = existingStatus.Duration;
                        request.Destroy();
                        break;
                    }
                }
            }
        }
    }
}
