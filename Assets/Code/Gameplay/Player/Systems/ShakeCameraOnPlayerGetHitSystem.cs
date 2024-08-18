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
        private IGroup<GameEntity> _entities;
        private GameContext _gameContext;

        public ShakeCameraOnPlayerGetHitSystem(GameContext gameContext, IShakeService shakeService, IUIService uiService)
        {
            _gameContext = gameContext;
            _uiService = uiService;
            _shakeService = shakeService;

            _players = gameContext.GetGroup(GameMatcher
                .AllOf(
                    GameMatcher.Player,
                    GameMatcher.Transform));

            _entities = gameContext.GetGroup(GameMatcher
                .AllOf(
                    GameMatcher.EffectReceived));
        }

        public void Execute()
        {
            foreach (var entity in _entities)
            {
                var player = _gameContext.GetEntityWithId(entity.TargetId);

                if (_players.ContainsEntity(player))
                {
                    _shakeService.Shake(Constants.Configs.ShakePlayerHit, 100f).Forget();

                    var hudWindow = _uiService.Get<HudWindow>();
                    hudWindow.DamageFlash();
                }
            }
        }
    }
}
