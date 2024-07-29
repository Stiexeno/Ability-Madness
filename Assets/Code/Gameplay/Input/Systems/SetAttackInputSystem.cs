using Entitas;
using UnityEngine.InputSystem;

namespace AbilityMadness.Code.Gameplay.Input.Systems
{
    public class SetAttackInputSystem : IExecuteSystem
    {
        private InputAction _attackInput;
        private IGroup<GameEntity> _inputs;

        public SetAttackInputSystem(Contexts contexts, PlayerInput playerInput)
        {
            _attackInput = playerInput.actions[Constants.Input.Attack];

            _inputs = contexts.game.GetGroup(GameMatcher
                .AllOf(GameMatcher.Input));
        }

        public void Execute()
        {
            foreach (var input in _inputs)
            {
                input.isAttackPressed = _attackInput.IsPressed();
            }
        }
    }
}
