using Entitas;

namespace AbilityMadness.Code.Gameplay.Vitals.Systems
{
    public class SetWaterUISystem  : IExecuteSystem
    {
        private IGroup<GameEntity> _players;
        private IUIService _uiService;

        public SetWaterUISystem(Contexts contexts, IUIService uiService)
        {
            _uiService = uiService;
            _players = contexts.game.GetGroup(GameMatcher
                .AllOf(
                    GameMatcher.Player,
                    GameMatcher.Water,
                    GameMatcher.MaxWater));
        }
        public void Execute()
        {
            var hudWindow = _uiService.Get<HudWindow>();

            foreach (var player in _players)
            {
                var waterValue = player.Water / player.MaxWater;
                hudWindow.SetWater(waterValue);
            }
        }
    }
}
