using Entitas;
using UnityEngine;
using UnityEngine.InputSystem;

namespace AbilityMadness.Code.Gameplay.Input.Systems
{
    public class SetLookInputSystem : IExecuteSystem
    {
        private InputAction _aimingInput;

        private IGroup<GameEntity> _inputs;
        private IGroup<GameEntity> _players;

        public SetLookInputSystem(Contexts contexts, PlayerInput playerInput)
        {
            _aimingInput = playerInput.actions[Constants.Input.Aiming];

            _inputs = contexts.game.GetGroup(GameMatcher
                .AllOf(GameMatcher.LookInput));

            _players = contexts.game.GetGroup(GameMatcher
                .AllOf(
                    GameMatcher.Player,
                    GameMatcher.WorldPosition));
        }

        public void Execute()
        {
            foreach (var input in _inputs)
            {
                foreach (var player in _players)
                {
                    var lookInput = UnityEngine.Camera.main.ScreenToWorldPoint(
                        _aimingInput.ReadValue<Vector2>());

                    lookInput -= player.WorldPosition;
                    lookInput = Vector2.ClampMagnitude(lookInput, 1);

                    input.ReplaceLookInput(new Vector2(lookInput.x, lookInput.y));
                }
            }
        }
    }
}
