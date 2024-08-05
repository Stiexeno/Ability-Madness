using Entitas;

namespace AbilityMadness.Code.Gameplay.Enemy.Systems
{
    public class MoveEnemyToPlayerSystem : IExecuteSystem
    {
        private IGroup<GameEntity> _enemies;
        private IGroup<GameEntity> _players;

        public MoveEnemyToPlayerSystem(GameContext gameContext)
        {
            _enemies = gameContext.GetGroup(GameMatcher
                .AllOf(
                    GameMatcher.Enemy,
                    GameMatcher.WorldPosition,
                    GameMatcher.LookDirection,
                    GameMatcher.Direction,
                    GameMatcher.Alive));

            _players = gameContext.GetGroup(GameMatcher
                .AllOf(
                    GameMatcher.Player,
                    GameMatcher.WorldPosition));
        }

        public void Execute()
        {
            foreach (var player in _players)
            {
                foreach (var enemy in _enemies)
                {
                    var direction = player.WorldPosition - enemy.WorldPosition;
                    enemy.LookDirection = direction.normalized;
                    enemy.Direction = direction.normalized;
                }
            }
        }
    }
}
