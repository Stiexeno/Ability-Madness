using Entitas;
using UnityEngine;
using UnityEngine.InputSystem;

namespace AbilityMadness.Code.Gameplay.Input.Systems
{
    public class SetAxisInputSystem : IExecuteSystem
    {
        private InputAction _movementInput;

        private IGroup<GameEntity> _inputs;

        public SetAxisInputSystem(Contexts contexts, PlayerInput playerInput)
        {
            _movementInput = playerInput.actions[Constants.Input.Movement];

            _inputs = contexts.game.GetGroup(GameMatcher
                .AllOf(GameMatcher.AxisInput));
        }

        public void Execute()
        {
            foreach (var input in _inputs)
            {
                input.ReplaceAxisInput(_movementInput.ReadValue<Vector2>());
            }
        }
    }
}
