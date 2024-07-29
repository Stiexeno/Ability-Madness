using Entitas;

namespace AbilityMadness.Code.Gameplay.Vitals.Systems
{
    public class SetHealthUISystem : IExecuteSystem
    {
        private IGroup<GameEntity> _players;
        private IUIService _uiService;

        public SetHealthUISystem(Contexts contexts, IUIService uiService)
        {
            _uiService = uiService;
            _players = contexts.game.GetGroup(GameMatcher
                .AllOf(
                    GameMatcher.Player,
                    GameMatcher.Health,
                    GameMatcher.MaxHealth));
        }
        public void Execute()
        {
            var hudWindow = _uiService.Get<HudWindow>();

            foreach (var player in _players)
            {
                var foodValue = player.Health / player.MaxHealth;
                hudWindow.SetHealth(foodValue);
            }
        }
    }
}
