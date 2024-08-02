using Entitas;

namespace AbilityMadness.Code.Gameplay.Enemy.Systems
{
    public class SetEnemyTargetPlayerSystem : IExecuteSystem
    {
        private IGroup<GameEntity> _enemies;
        private IGroup<GameEntity> _players;

        public SetEnemyTargetPlayerSystem(GameContext gameContext)
        {
            _enemies = gameContext.GetGroup(GameMatcher
                .AllOf(
                    GameMatcher.Enemy,
                    GameMatcher.TargetsInSight));

            _players = gameContext.GetGroup(GameMatcher
                .AllOf(
                    GameMatcher.Player,
                    GameMatcher.Id));
        }

        public void Execute()
        {
            foreach (var enemy in _enemies)
            foreach (var player in _players)
            {
                if (enemy.TargetsInSight.Count == 0)
                {
                    enemy.TargetsInSight.Add(player.Id);
                    continue;
                }

                enemy.TargetsInSight[0] = player.Id;
            }
        }
    }
}
