using AbilityMadness.Code.Gameplay.UI.Hud;
using AbilityMadness.Infrastructure.UI;
using Entitas;

namespace AbilityMadness.Code.Gameplay.Weapons.Systems.View
{
    public class RefreshAmmoWidgetSystem : IExecuteSystem
    {
        private IGroup<GameEntity> _weapons;
        private IUIService _uiService;

        public RefreshAmmoWidgetSystem(GameContext gameContext, IUIService uiService)
        {
            _uiService = uiService;
            _weapons = gameContext.GetGroup(GameMatcher
                .AllOf(
                    GameMatcher.Weapon,
                    GameMatcher.AmmoCapacity,
                    GameMatcher.MaxAmmoCapacity));
        }

        public void Execute()
        {
            foreach (var weapon in _weapons)
            {
                var hudWindow = _uiService.Get<HudWindow>();
                hudWindow.AmmoWidget.Refresh(weapon.AmmoCapacity);
            }
        }
    }
}
