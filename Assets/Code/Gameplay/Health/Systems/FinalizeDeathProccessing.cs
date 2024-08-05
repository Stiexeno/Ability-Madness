using System.Collections.Generic;
using Entitas;

namespace AbilityMadness.Code.Gameplay.Health.Systems
{
    public class FinalizeDeathProccessing : IExecuteSystem
    {
        private readonly IGroup<GameEntity> _enemies;
        private readonly List<GameEntity> _buffer = new(1);

        public FinalizeDeathProccessing(GameContext game)
        {
            _enemies = game.GetGroup(GameMatcher
                .AllOf(
                    GameMatcher.Dead,
                    GameMatcher.ProccessingDeath));
        }

        public void Execute()
        {
            foreach (GameEntity hero in _enemies.GetEntities(_buffer))
            {
                hero.isProccessingDeath = false;
            }
        }
    }
}
