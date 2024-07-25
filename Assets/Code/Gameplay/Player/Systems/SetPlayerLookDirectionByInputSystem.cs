using Entitas;

namespace AbilityMadness.Systems
{
    public class SetPlayerLookDirectionByInputSystem : IExecuteSystem
    {
        private IGroup<GameEntity> _players;
        private IGroup<GameEntity> _lookInputs;

        public SetPlayerLookDirectionByInputSystem(Contexts contexts)
        {
            _players = contexts.game.GetGroup(GameMatcher
                .AllOf(GameMatcher.Player));

            _lookInputs = contexts.game.GetGroup(GameMatcher
                .AllOf(GameMatcher.LookInput));
        }

        public void Execute()
        {
            foreach (GameEntity input in _lookInputs)
            foreach (GameEntity player in _players)
            {
                if (input.hasLookInput)
                    player.ReplaceLookDirection(input.LookInput.normalized);
                else
                    player.ReplaceLookDirection(UnityEngine.Vector2.zero);
            }
        }
    }
}
