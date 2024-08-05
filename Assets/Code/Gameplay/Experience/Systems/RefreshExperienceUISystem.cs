using Entitas;

namespace AbilityMadness.Code.Gameplay.Experience.Systems
{
    public class RefreshExperienceUISystem : IExecuteSystem
    {
        private IUIService _uiService;
        private IGroup<GameEntity> _entities;

        public RefreshExperienceUISystem(GameContext gameContext, IUIService uiService)
        {
            _uiService = uiService;
            _entities = gameContext.GetGroup(GameMatcher
                .AllOf(
                    GameMatcher.Experience,
                    GameMatcher.MaxExperience));
        }

        public void Execute()
        {
            foreach (var entity in _entities)
            {
                var hudWindow = _uiService.Get<HudWindow>();
                hudWindow.SetExperience(entity.Experience, entity.MaxExperience);
            }
        }
    }
}
