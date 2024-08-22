using AbilityMadness.Code.Gameplay.Status.Factory;
using Entitas;

namespace AbilityMadness.Code.Gameplay.Status.Systems
{
    public class ApplyStatusesSystem : IExecuteSystem
    {
        private IGroup<GameEntity> _entities;
        private IGroup<GameEntity> _owners;
        private GameContext _gameContext;
        private IGroup<GameEntity> _targets;
        private IStatusFactory _statusFactory;
        private IGroup<GameEntity> _existingStatuses;

        public ApplyStatusesSystem(GameContext gameContext, IStatusFactory statusFactory)
        {
            _statusFactory = statusFactory;
            _gameContext = gameContext;
            _entities = gameContext.GetGroup(GameMatcher
                .AllOf(
                    GameMatcher.EffectDealt,
                    GameMatcher.ProducerId,
                    GameMatcher.TargetId));

            _owners = gameContext.GetGroup(GameMatcher
                .AllOf(
                    GameMatcher.StatusSetups));

            _targets = gameContext.GetGroup(GameMatcher
                .AllOf(
                    GameMatcher.Id,
                    GameMatcher.Alive));

            _existingStatuses = gameContext.GetGroup(GameMatcher
                .AllOf(
                    GameMatcher.Status,
                    GameMatcher.TargetId,
                    GameMatcher.StatusTypeId,
                    GameMatcher.Duration,
                    GameMatcher.TimeLeft,
                    GameMatcher.Id));
        }

        public void Execute()
        {
            foreach (var entity in _entities)
            {
                var owner = _gameContext.GetEntityWithId(entity.ProducerId);
                var target = _gameContext.GetEntityWithId(entity.TargetId);

                if (_owners.ContainsEntity(owner) && _targets.ContainsEntity(target))
                {
                    foreach (var statusSetup in owner.StatusSetups)
                    {
                        var statusExists = false;
                        foreach (var existingStatus in _existingStatuses)
                        {
                            if (existingStatus.StatusTypeId == statusSetup.type && existingStatus.TargetId == target.Id)
                            {
                                existingStatus.TimeLeft = existingStatus.Duration;
                                statusExists = true;
                            }
                        }

                        if (statusExists == false)
                        {
                            _statusFactory.CreateStatus(statusSetup, owner.Id, target.Id);
                        }
                    }
                }
            }
        }
    }
}
