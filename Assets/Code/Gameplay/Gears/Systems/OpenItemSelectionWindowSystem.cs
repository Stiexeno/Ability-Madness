using AbilityMadness.Code.Gameplay.Upgrades.Services;
using Entitas;

namespace AbilityMadness.Code.Gameplay.Gears.Systems
{
    public class OpenItemSelectionWindowSystem : IExecuteSystem
    {
        private IGroup<GameEntity> _players;
        private IUIService _uiService;
        private IUpgradeService _upgradeService;

        public OpenItemSelectionWindowSystem(GameContext gameContext, IUpgradeService upgradeService)
        {
            _upgradeService = upgradeService;

            _players = gameContext.GetGroup(GameMatcher
                .AllOf(
                    GameMatcher.Player,
                    GameMatcher.LevelUp));
        }

        public void Execute()
        {
            foreach (var _ in _players)
            {
                _upgradeService.Upgrade();
            }
        }
    }
}
