using System.Collections.Generic;
using Entitas;

namespace AbilityMadness.Code.Gameplay.Chest.Systems
{
    public class RemoveChestInteractPlayerExitSystem : IExecuteSystem
    {
        private readonly List<GameEntity> _buffer = new(32);

        private IGroup<GameEntity> _interactables;
        private IGroup<GameEntity> _triggers;

        public RemoveChestInteractPlayerExitSystem(Contexts contexts)
        {
            _interactables = contexts.game.GetGroup(GameMatcher
                .AllOf(
                    GameMatcher.ChestInteracting,
                    GameMatcher.InteractBehaviour)
                .NoneOf(GameMatcher.PlayerTriggered));
        }

        public void Execute()
        {
            foreach (var interactable in _interactables.GetEntities(_buffer))
            {
                interactable.isChestInteracting = false;
                interactable.InteractBehaviour.SetInteracted(false);
            }
        }
    }
}
