using System.Collections.Generic;
using AbilityMadness.Code.Common.Cooldown;
using Entitas;
using UnityEngine;

namespace AbilityMadness.Code.Gameplay.Abilities.Systems
{
    public class PutAbilityOnCooldownSystem : ICleanupSystem
    {
        private readonly List<GameEntity> _buffer = new(32);

        private IGroup<GameEntity> _abilities;

        public PutAbilityOnCooldownSystem(Contexts contexts)
        {
            _abilities = contexts.game.GetGroup(GameMatcher
                .AllOf(
                    GameMatcher.Ability,
                    GameMatcher.Ready,
                    GameMatcher.Cooldown));
        }

        public void Cleanup()
        {
            foreach (var ability in _abilities.GetEntities(_buffer))
            {
                ability.SetOnCooldown();
                ability.isReady = false;
            }
        }
    }
}
