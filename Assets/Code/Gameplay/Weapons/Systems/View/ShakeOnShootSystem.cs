using AbilityMadness.Code.Infrastructure.Camera.Shake;
using Entitas;

namespace AbilityMadness.Code.Gameplay.Weapons.Systems.View
{
    public class ShakeOnShootSystem : IExecuteSystem
    {
        private IGroup<GameEntity> _weapons;
        private IGroup<GameEntity> _players;
        private GameContext _gameContext;
        private IShakeService _shakeService;

        public ShakeOnShootSystem(GameContext gameContext, IShakeService shakeService)
        {
            _shakeService = shakeService;
            _gameContext = gameContext;
            _weapons = gameContext.GetGroup(GameMatcher
                .AllOf(
                    GameMatcher.Weapon,
                    GameMatcher.Shot));

            _players = gameContext.GetGroup(GameMatcher
                .AllOf(
                    GameMatcher.Player,
                    GameMatcher.Id));
        }

        public void Execute()
        {
            foreach (var weapon in _weapons)
            {
                var owner = _gameContext.GetEntityWithId(weapon.OwnerId);

                if (_players.ContainsEntity(owner))
                {
                   _shakeService.Shake(Constants.Configs.ShakeShoot, 15f);
                }
            }
        }
    }
}
