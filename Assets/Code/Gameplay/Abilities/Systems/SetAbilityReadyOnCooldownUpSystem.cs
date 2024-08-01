using System.Collections.Generic;
using Entitas;

namespace AbilityMadness.Code.Gameplay.Abilities.Systems
{
    public class SetAbilityReadyOnCooldownUpSystem : IExecuteSystem
    {
        private readonly List<GameEntity> _buffer = new(32);
        private IGroup<GameEntity> _abilities;

        public SetAbilityReadyOnCooldownUpSystem(Contexts contexts)
        {
            _abilities = contexts.game.GetGroup(GameMatcher
                .AllOf(
                    GameMatcher.Ability,
                    GameMatcher.CooldownUp,
                    GameMatcher.AutoLaunch));
        }

        public void Execute()
        {
            foreach (var ability in _abilities.GetEntities(_buffer))
            {
                ability.isReady = true;
            }
        }
    }
}
