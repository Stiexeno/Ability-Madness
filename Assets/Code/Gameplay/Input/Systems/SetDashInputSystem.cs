using Entitas;
using UnityEngine.InputSystem;

namespace AbilityMadness.Code.Gameplay.Input.Systems
{
    public class SetDashInputSystem : IExecuteSystem
    {
        private InputAction _dashInput;
        private IGroup<GameEntity> _inputs;

        public SetDashInputSystem(Contexts contexts, PlayerInput playerInput)
        {
            _dashInput = playerInput.actions[Constants.Input.Dash];

            _inputs = contexts.game.GetGroup(GameMatcher
                .AllOf(GameMatcher.Input));
        }

        public void Execute()
        {
            foreach (var input in _inputs)
            {
                input.isDashPressed = _dashInput.IsPressed();
            }
        }
    }
}
