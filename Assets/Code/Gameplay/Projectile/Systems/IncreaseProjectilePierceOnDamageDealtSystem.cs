using Entitas;

namespace AbilityMadness.Code.Gameplay.Projectile.Systems
{
    public class IncreaseProjectilePierceOnDamageDealtSystem : IExecuteSystem
    {
        private IGroup<GameEntity> _projectiles;
        private IGroup<GameEntity> _entities;
        private GameContext _gameContext;

        public IncreaseProjectilePierceOnDamageDealtSystem(GameContext gameContext)
        {
            _gameContext = gameContext;
            _projectiles = gameContext.GetGroup(GameMatcher
                .AllOf(
                    GameMatcher.Projectile,
                    GameMatcher.PiercedAmount));

            _entities = gameContext.GetGroup(GameMatcher
                .AllOf(
                    GameMatcher.EffectDealt));
        }

        public void Execute()
        {
            foreach (var entity in _entities)
            {
                var projectile = _gameContext.GetEntityWithId(entity.EffectDealt);

                if (_projectiles.ContainsEntity(projectile))
                {
                    projectile.PiercedAmount++;
                }
            }
        }
    }
}
