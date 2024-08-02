using Entitas;

namespace AbilityMadness.Code.Gameplay.Enemy.Systems
{
    public class MoveEnemyToTargetSystem : IExecuteSystem
    {
        private IGroup<GameEntity> _enemies;
        private GameContext _gameContext;
        private IGroup<GameEntity> _targets;

        public MoveEnemyToTargetSystem(GameContext gameContext)
        {
            _gameContext = gameContext;
            _enemies = gameContext.GetGroup(GameMatcher
                .AllOf(
                    GameMatcher.Enemy,
                    GameMatcher.TargetsInSight,
                    GameMatcher.WorldPosition,
                    GameMatcher.LookDirection,
                    GameMatcher.TransformMovement));

            _targets = gameContext.GetGroup(GameMatcher
                .AllOf(
                    GameMatcher.Id,
                    GameMatcher.WorldPosition));
        }

        public void Execute()
        {
            foreach (var enemy in _enemies)
            {
                var target = _gameContext.GetEntityWithId(enemy.TargetsInSight[0]);

                if (_targets.ContainsEntity(target) == false)
                    continue;

                var direction = target.WorldPosition - enemy.WorldPosition;
                enemy.LookDirection = direction.normalized;
                enemy.Direction = direction.normalized;
            }
        }
    }
}
