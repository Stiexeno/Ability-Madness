using Entitas;

namespace AbilityMadness.Code.Gameplay.Abilities.Systems
{
    public class PrepareManualLaunchAbilitySystem : IExecuteSystem
    {
        private IGroup<GameEntity> _abilities;
        private Contexts _contexts;
        private IGroup<GameEntity> _attackingEntities;

        public PrepareManualLaunchAbilitySystem(Contexts contexts)
        {
            _contexts = contexts;

            _abilities = contexts.game.GetGroup(GameMatcher
                .AllOf(
                    GameMatcher.Ability,
                    GameMatcher.ManualLaunch,
                    GameMatcher.OwnerId));

            _attackingEntities = contexts.game.GetGroup(GameMatcher
                .AllOf(GameMatcher.Attacking));
        }

        public void Execute()
        {
            foreach (var ability in _abilities)
            {
                var owner = _contexts.game.GetEntityWithId(ability.OwnerId);
                
                ability.isReady = _attackingEntities.ContainsEntity(owner) && ability.hasCooldown == false;
            }
        }
    }
}
