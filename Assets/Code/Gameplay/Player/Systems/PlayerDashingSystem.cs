using Entitas;

namespace AbilityMadness.Code.Gameplay.Player.Systems
{
    public class PlayerDashingSystem : IExecuteSystem
    {
        private IGroup<GameEntity> _players;
        private IGroup<GameEntity> _inputs;

        public PlayerDashingSystem(Contexts contexts)
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
            foreach (GameEntity input in _inputs)
            foreach (GameEntity player in _players)
            {
                player.isRequestDash = input.isDashPressed;
            }
        }
    }
}
