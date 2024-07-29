using Entitas;

namespace AbilityMadness.Code.Gameplay.Abilities.Systems
{
    public class PrepareManualLaunchAbilitySystem : IExecuteSystem
    {
        private IGroup<GameEntity> _abilities;
        private Contexts _contexts;

        public PrepareManualLaunchAbilitySystem(Contexts contexts)
        {
            _contexts = contexts;

            _abilities = contexts.game.GetGroup(GameMatcher
                .AllOf(
                    GameMatcher.Ability,
                    GameMatcher.ManualLaunch,
                    GameMatcher.OwnerId));
        }

        public void Execute()
        {
            foreach (var ability in _abilities)
            {
                var owner = _contexts.game.GetEntityWithId(ability.OwnerId);

                if (owner == null)
                    continue;

                ability.isReady = owner.isAttacking && ability.hasCooldown == false;
            }
        }
    }
}
