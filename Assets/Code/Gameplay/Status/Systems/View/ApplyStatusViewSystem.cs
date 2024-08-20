using System;
using System.Collections.Generic;
using AbilityMadness.Code.Gameplay.Status.Factory;
using Entitas;

namespace AbilityMadness.Code.Gameplay.Status.Systems.View
{
    public class ApplyStatusViewSystem : IExecuteSystem
    {
        private readonly List<GameEntity> _buffer = new(32);
        private IGroup<GameEntity> _statuses;

        private IStatusViewFactory _statusViewFactory;

        public ApplyStatusViewSystem(GameContext gameContext, IStatusViewFactory statusViewFactory)
        {
            _statusViewFactory = statusViewFactory;
            _statuses = gameContext.GetGroup(GameMatcher
                .AllOf(
                    GameMatcher.Status,
                    GameMatcher.Id,
                    GameMatcher.TargetId,
                    GameMatcher.ProducerId,
                    GameMatcher.StatusTypeId)
                .NoneOf(
                    GameMatcher.StatusViewApplied));
        }

        public void Execute()
        {
            foreach (var status in _statuses.GetEntities(_buffer))
            {
                _statusViewFactory.CreateStatusView(status.StatusTypeId, status.Id, status.TargetId);
                status.isStatusViewApplied = true;
            }
        }
    }
}
