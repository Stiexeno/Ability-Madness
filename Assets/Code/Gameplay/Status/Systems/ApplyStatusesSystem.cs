using System.Collections.Generic;
using AbilityMadness.Code.Gameplay.Status.Factory;
using Entitas;

namespace AbilityMadness.Code.Gameplay.Status.Systems
{
    public class ApplyStatusesSystem : IExecuteSystem
    {
        private readonly List<GameEntity> _buffer = new(32);
        private GameContext _gameContext;

        private IGroup<GameEntity> _targets;
        private IGroup<GameEntity> _existingStatuses;
        private IGroup<GameEntity> _requests;

        private IStatusFactory _statusFactory;

        public ApplyStatusesSystem(GameContext gameContext, IStatusFactory statusFactory)
        {
            _statusFactory = statusFactory;
            _gameContext = gameContext;

           _requests = gameContext.GetGroup(GameMatcher
               .AllOf(
                   GameMatcher.StatusRequest,
                   GameMatcher.TargetId,
                   GameMatcher.ProducerId,
                   GameMatcher.StatusSetup));

            _targets = gameContext.GetGroup(GameMatcher
                .AllOf(
                    GameMatcher.Id,
                    GameMatcher.Alive));
        }

        public void Execute()
        {
            foreach (var request in _requests.GetEntities(_buffer))
            {
                var target = _gameContext.GetEntityWithId(request.TargetId);

                if (_targets.ContainsEntity(target))
                {
                    _statusFactory.CreateStatus(request.StatusSetup, request.ProducerId, target.Id);
                    request.Destroy();
                }
            }
        }
    }
}
