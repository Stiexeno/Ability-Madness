using AbilityMadness.Code.Extensions;
using Entitas;

namespace AbilityMadness.Code.Gameplay.Health.Systems
{
    public class RefreshHealthbarSystem : IExecuteSystem
    {
        private IGroup<GameEntity> _healthbars;
        private IGroup<GameEntity> _owners;
        private GameContext _gameContext;

        public RefreshHealthbarSystem(GameContext gameContext)
        {
            _gameContext = gameContext;
            _healthbars = gameContext.GetGroup(GameMatcher
                .AllOf(
                    GameMatcher.Healthbar,
                    GameMatcher.TargetId,
                    GameMatcher.WorldPosition,
                    GameMatcher.View));

            _owners = gameContext.GetGroup(GameMatcher
                .AllOf(
                    GameMatcher.Id,
                    GameMatcher.Health,
                    GameMatcher.MaxHealth,
                    GameMatcher.Head));
        }

        public void Execute()
        {
            foreach (var healthbar in _healthbars)
            {
                var owner = _gameContext.GetEntityWithId(healthbar.TargetId);

                if (_owners.ContainsEntity(owner))
                {
                    healthbar.WorldPosition = owner.Head.position.AddY(0.25f);
                    healthbar.Healthbar.SetHealth(owner.Health / (float)owner.MaxHealth);
                }
            }
        }
    }
}
