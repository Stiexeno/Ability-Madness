using AbilityMadness.Code.Gameplay.Status.Services;
using Entitas;

namespace AbilityMadness.Code.Gameplay.Status.Systems
{
    public class ApplyStatusOnEffectDealtSystem : IExecuteSystem
    {
        private IGroup<GameEntity> _entities;
        private IGroup<GameEntity> _owners;
        private GameContext _gameContext;
        private IGroup<GameEntity> _targets;
        private IStatusService _statusService;

        public ApplyStatusOnEffectDealtSystem(GameContext gameContext, IStatusService statusService)
        {
            _statusService = statusService;
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
                        _statusService.ApplyStatus(statusSetup, owner.Id, target.Id);
                    }
                }
            }
        }
    }
}
