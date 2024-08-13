using AbilityMadness.Code.Gameplay.Items.Windows;
using Entitas;

namespace AbilityMadness.Code.Gameplay.Items.Systems
{
    public class OpenItemSelectionWindowSystem : IExecuteSystem
    {
        private IGroup<GameEntity> _players;
        private IUIService _uiService;

        public OpenItemSelectionWindowSystem(GameContext gameContext, IUIService uiService)
        {
            _uiService = uiService;

            _players = gameContext.GetGroup(GameMatcher
                .AllOf(
                    GameMatcher.Player,
                    GameMatcher.LevelUp));
        }

        public void Execute()
        {
            foreach (var _ in _players)
            {
                _uiService.Open<ItemSelectionWindow>();
            }
        }
    }
}
