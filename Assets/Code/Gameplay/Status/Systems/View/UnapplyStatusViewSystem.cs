using Entitas;

namespace AbilityMadness.Code.Gameplay.Status.Systems.View
{
    public class UnapplyStatusViewSystem : IExecuteSystem
    {
        private GameContext _gameContext;
        private IGroup<GameEntity> _statusViews;
        private IGroup<GameEntity> _statuses;

        public UnapplyStatusViewSystem(GameContext gameContext)
        {
            _gameContext = gameContext;
            _statusViews = gameContext.GetGroup(GameMatcher
                .AllOf(
                    GameMatcher.StatusView,
                    GameMatcher.TargetId,
                    GameMatcher.ProducerId));

            _statuses = gameContext.GetGroup(GameMatcher
                .AllOf(
                    GameMatcher.Status,
                    GameMatcher.Id,
                    GameMatcher.Depleted));
        }

        public void Execute()
        {
            foreach (var statusView in _statusViews)
            {
                var status = _gameContext.GetEntityWithId(statusView.ProducerId);

                if (_statuses.ContainsEntity(status))
                {
                    statusView.isDestructed = true;
                }
            }
        }
    }
}
