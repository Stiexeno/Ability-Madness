using Entitas;

namespace AbilityMadness.Code.Gameplay.Vitals.Systems
{
    public class SetFoodUISystem : IExecuteSystem
    {
        private IGroup<GameEntity> _players;
        private IUIService _uiService;

        public SetFoodUISystem(Contexts contexts, IUIService uiService)
        {
            _uiService = uiService;
            _players = contexts.game.GetGroup(GameMatcher
                .AllOf(
                    GameMatcher.Player,
                    GameMatcher.Food,
                    GameMatcher.MaxFood));
        }
        public void Execute()
        {
            var hudWindow = _uiService.Get<HudWindow>();

            foreach (var player in _players)
            {
                var foodValue = player.Food / player.MaxFood;
                hudWindow.SetFood(foodValue);
            }
        }
    }
}
