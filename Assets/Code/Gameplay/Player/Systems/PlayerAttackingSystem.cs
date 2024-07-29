using Entitas;

namespace AbilityMadness.Systems
{
    public class PlayerAttackingSystem : IExecuteSystem
    {
        private IGroup<GameEntity> _players;
        private IGroup<GameEntity> _inputs;

        public PlayerAttackingSystem(Contexts contexts)
        {
            _players = contexts.game.GetGroup(GameMatcher
                .AllOf(
                    GameMatcher.Player));

            _inputs = contexts.game.GetGroup(GameMatcher
                .AllOf(
                    GameMatcher.Input));
        }

        public void Execute()
        {
            foreach (var input in _inputs)
            foreach (var player in _players)
            {
                player.isAttacking = input.isAttackPressed;
            }
        }
    }
}
