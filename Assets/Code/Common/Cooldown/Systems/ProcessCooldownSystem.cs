using System.Collections.Generic;
using Entitas;
using UnityEngine;

namespace AbilityMadness.Code.Common.Cooldown.Systems
{
    public class ProcessCooldownSystem : IExecuteSystem
    {
        private readonly List<GameEntity> _buffer = new(32);
        private IGroup<GameEntity> _cooldowns;

        public ProcessCooldownSystem(GameContext gameContext)
        {
            _cooldowns = gameContext.GetGroup(GameMatcher
                .AllOf(
                    GameMatcher.Cooldown,
                    GameMatcher.CooldownLeft));
        }

        public void Execute()
        {
            foreach (var cooldown in _cooldowns.GetEntities(_buffer))
            {
                cooldown.CooldownLeft += Time.deltaTime;

                if (cooldown.CooldownLeft >= cooldown.Cooldown)
                {
                    cooldown.RemoveCooldown();
                    cooldown.RemoveCooldownLeft();
                    cooldown.isCooldownUp = true;
                }
            }
        }
    }
}
