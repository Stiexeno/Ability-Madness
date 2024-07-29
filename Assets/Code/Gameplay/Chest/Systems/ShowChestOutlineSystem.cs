using Entitas;

namespace AbilityMadness.Code.Gameplay.Chest.Systems
{
    public class ShowChestOutlineSystem : IExecuteSystem
    {
        private IGroup<GameEntity> _interactables;
        private IGroup<GameEntity> _triggers;

        public ShowChestOutlineSystem(Contexts contexts)
        {
            _interactables = contexts.game.GetGroup(GameMatcher
                .AllOf(
                    GameMatcher.Chest,
                    GameMatcher.InteractBehaviour));
        }

        public void Execute()
        {
            foreach (var interactable in _interactables)
            {
                interactable.InteractBehaviour.SetInteracted(interactable.isPlayerInTrigger && interactable.isMouseInHover);
            }
        }
    }
}
