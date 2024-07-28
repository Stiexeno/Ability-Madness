using System.Collections.Generic;
using Entitas;

namespace AbilityMadness.Code.Gameplay.Chest.Systems
{
    public class MarkChestInteractPlayerEnterSystem : IExecuteSystem
    {
        private readonly List<GameEntity> _buffer = new(32);

        private IGroup<GameEntity> _interactables;
        private IGroup<GameEntity> _triggers;

        public MarkChestInteractPlayerEnterSystem(Contexts contexts)
        {
            _interactables = contexts.game.GetGroup(GameMatcher
                .AllOf(
                    GameMatcher.PlayerTriggered,
                    GameMatcher.InteractBehaviour)
                .NoneOf(
                    GameMatcher.ChestInteracting));
        }

        public void Execute()
        {
            foreach (var interactable in _interactables.GetEntities(_buffer))
            {
                interactable.isChestInteracting = true;
                interactable.InteractBehaviour.SetInteracted(true);
            }
        }
    }
}
