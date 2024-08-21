using System;
using AbilityMadness.Code.Infrastructure.Cursors;
using Entitas;

namespace AbilityMadness.Code.Gameplay.Chest.Systems
{
    public class SetChestCursorInteractSystem : IExecuteSystem
    {
        private const CursorType CURSOR_TYPE = CursorType.Interact;

        private IGroup<GameEntity> _chests;
        private ICursorService _cursorService;

        public SetChestCursorInteractSystem(Contexts contexts)
        {
            _chests = contexts.game.GetGroup(GameMatcher
                .AllOf(
                    GameMatcher.Chest));
        }

        public void Execute()
        {
            var cursorType = CursorType.Default;

            foreach (var chest in _chests)
            {
                if (chest.isPlayerInTrigger && chest.isMouseInHover)
                {
                    cursorType = CURSOR_TYPE;
                    break;
                }
            }

           // _cursorService.SetCursor(cursorType);
        }
    }
}
