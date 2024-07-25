using Entitas;
using UnityEngine;
using UnityEngine.InputSystem;

namespace AbilityMadness.Code.Gameplay.Input.Systems
{
    public class SetLookInputSystem : IExecuteSystem
    {
        private InputAction _aimingInput;

        private IGroup<GameEntity> _inputs;

        public SetLookInputSystem(Contexts contexts, PlayerInput playerInput)
        {
            _aimingInput = playerInput.actions[Constants.Input.Aiming];

            _inputs = contexts.game.GetGroup(GameMatcher
                .AllOf(GameMatcher.LookInput));
        }

        public void Execute()
        {
            foreach (var input in _inputs)
            {
                var lookInput = UnityEngine.Camera.main.ScreenToWorldPoint(_aimingInput.ReadValue<Vector2>());
                input.ReplaceLookInput(new Vector2(lookInput.x, lookInput.y));
            }
        }
    }
}
