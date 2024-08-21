using AbilityMadness.Infrastructure.UI;
using Entitas;
using UnityEngine;

namespace AbilityMadness.Code.Gameplay.Round.Systems
{
    public class RefreshRoundTimerUISystem : IExecuteSystem
    {
        private IUIService _uiService;
        private IGroup<GameEntity> _entities;

        public RefreshRoundTimerUISystem(GameContext gameContext, IUIService uiService)
        {
            _uiService = uiService;
            _entities = gameContext.GetGroup(GameMatcher
                .AllOf(
                    GameMatcher.RoundTime,
                    GameMatcher.TimeElapsed));
        }

        public void Execute()
        {
            foreach (var entity in _entities)
            {
                var hudWindow = _uiService.Get<HudWindow>();
                hudWindow.SetRoundTime(Mathf.RoundToInt(entity.TimeElapsed));
            }
        }
    }
}
