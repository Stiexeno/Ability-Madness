using Entitas;

namespace AbilityMadness.Code.Gameplay.Player.Systems
{
    public class SetPlayerDirectionByInputSystem : IExecuteSystem
    {
        private IGroup<GameEntity> _players;
        private IGroup<GameEntity> _axisInputs;

        public SetPlayerDirectionByInputSystem(Contexts contexts)
        {
            _players = contexts.game.GetGroup(GameMatcher
                .AllOf(GameMatcher.Player)
                .NoneOf(
                    GameMatcher.Dashing));

            _axisInputs = contexts.game.GetGroup(GameMatcher
                .AllOf(GameMatcher.AxisInput));
        }

        public void Execute()
        {
            foreach (GameEntity input in _axisInputs)
            foreach (GameEntity player in _players)
            {
                if (input.hasAxisInput)
                    player.ReplaceDirection(input.AxisInput.normalized);
                else
                    player.ReplaceDirection(UnityEngine.Vector2.zero);
            }
        }
    }
}
