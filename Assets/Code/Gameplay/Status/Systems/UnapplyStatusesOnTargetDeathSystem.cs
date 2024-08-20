using Entitas;

namespace AbilityMadness.Code.Gameplay.Status.Systems
{
    public class UnapplyStatusesOnTargetDeathSystem : IExecuteSystem
    {
        private IGroup<GameEntity> _statuses;
        private IGroup<GameEntity> _targets;
        private GameContext _gameContext;

        public UnapplyStatusesOnTargetDeathSystem(GameContext gameContext)
        {
            _gameContext = gameContext;
            _statuses = gameContext.GetGroup(GameMatcher
                .AllOf(
                    GameMatcher.Status,
                    GameMatcher.TargetId));

            _targets = gameContext.GetGroup(GameMatcher
                .AllOf(
                    GameMatcher.Id,
                    GameMatcher.Dead));
        }

        public void Execute()
        {
            foreach (var status in _statuses)
            {
                var target = _gameContext.GetEntityWithId(status.TargetId);

                if (_targets.ContainsEntity(target))
                {
                    status.isDepleted = true;
                }
            }
        }
    }
}
