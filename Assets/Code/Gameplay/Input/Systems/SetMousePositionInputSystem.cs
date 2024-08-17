using System;
using Entitas;
using UnityEngine;
using UnityEngine.InputSystem;

namespace AbilityMadness.Code.Gameplay.Input.Systems
{
    public class SetMousePositionInputSystem : IExecuteSystem
    {
        private InputAction _mouseInput;
        private IGroup<GameEntity> _inputs;

        public SetMousePositionInputSystem(Contexts contexts, PlayerInput playerInput)
        {
            _mouseInput = playerInput.actions[Constants.Input.MousePosition];

            _inputs = contexts.game.GetGroup(GameMatcher
                .AllOf(GameMatcher.MousePosition));
        }

        public void Execute()
        {
            foreach (var input in _inputs)
            {
                var lookInput = UnityEngine.Camera.main.ScreenToWorldPoint(
                    _mouseInput.ReadValue<Vector2>());

                input.MousePosition = lookInput;
            }
        }
    }
}
