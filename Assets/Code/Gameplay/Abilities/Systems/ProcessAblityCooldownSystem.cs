using System.Collections.Generic;
using Entitas;
using UnityEngine;

namespace AbilityMadness.Code.Gameplay.Abilities.Systems
{
    public class ProcessAblityCooldownSystem : IExecuteSystem
    {
        private readonly List<GameEntity> _buffer = new(32);
        private IGroup<GameEntity> _abilities;

        public ProcessAblityCooldownSystem(Contexts contexts)
        {
            _abilities = contexts.game.GetGroup(GameMatcher
                .AllOf(
                    GameMatcher.Ability,
                    GameMatcher.Cooldown));
        }

        public void Execute()
        {
            foreach (var ability in _abilities.GetEntities(_buffer))
            {
                ability.Cooldown -= Time.deltaTime;

                if (ability.Cooldown <= 0)
                {
                    ability.RemoveCooldown();

                    if (ability.isManualLaunch == false)
                    {
                        ability.isReady = true;
                    }
                }
            }
        }
    }
}
