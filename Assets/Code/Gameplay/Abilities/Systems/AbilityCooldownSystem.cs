using System.Collections.Generic;
using Entitas;

namespace AbilityMadness.Code.Gameplay.Abilities.Systems
{
    public class AbilityCooldownSystem : ICleanupSystem
    {
        private readonly List<GameEntity> _buffer = new(32);

        private IGroup<GameEntity> _abilities;

        public AbilityCooldownSystem(Contexts contexts)
        {
            _abilities = contexts.game.GetGroup(GameMatcher
                .AllOf(
                    GameMatcher.Ability,
                    GameMatcher.Ready)
                .NoneOf(GameMatcher.Cooldown));
        }

        public void Cleanup()
        {
            foreach (var ability in _abilities.GetEntities(_buffer))
            {
                ability.ReplaceCooldown(0.05f);
            }
        }
    }
}
