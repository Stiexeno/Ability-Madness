using AbilityMadness.Infrastructure.UI;
using Entitas;

namespace AbilityMadness.Code.Gameplay.Health.Systems
{
    public class RefreshHealthUISystem : IExecuteSystem
    {
        private IUIService _uiService;
        private IGroup<GameEntity> _entities;

        public RefreshHealthUISystem(GameContext gameContext, IUIService uiService)
        {
            _uiService = uiService;
            _entities = gameContext.GetGroup(GameMatcher
                .AllOf(
                    GameMatcher.Player,
                    GameMatcher.Health,
                    GameMatcher.MaxHealth));
        }

        public void Execute()
        {
            foreach (var entity in _entities)
            {
                var hudWindow = _uiService.Get<HudWindow>();
                hudWindow.SetHealth(entity.Health, entity.MaxHealth);
            }
        }
    }
}
