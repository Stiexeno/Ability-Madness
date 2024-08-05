using AbilityMadness.Code.Infrastructure.Services.Camera.Shake;
using Entitas;
using UnityEngine;

namespace AbilityMadness.Code.Gameplay.Player.Systems
{
    public class ShakeCameraOnPlayerGetHitSystem : IExecuteSystem
    {
        private IGroup<GameEntity> _players;
        private IShakeService _shakeService;
        private IUIService _uiService;

        public ShakeCameraOnPlayerGetHitSystem(GameContext gameContext, IShakeService shakeService, IUIService uiService)
        {
            _uiService = uiService;
            _shakeService = shakeService;
            _players = gameContext.GetGroup(GameMatcher
                .AllOf(
                    GameMatcher.Player,
                    GameMatcher.DamageReceived,
                    GameMatcher.Transform));
        }

        public void Execute()
        {
            foreach (var player in _players)
            {
                _shakeService.Shake(Constants.Configs.ShakePlayerHit, 100f).Forget();

                var hudWindow = _uiService.Get<HudWindow>();
                hudWindow.DamageFlash();
            }
        }
    }
}
