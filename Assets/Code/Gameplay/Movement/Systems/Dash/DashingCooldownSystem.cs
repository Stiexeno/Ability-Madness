using System.Collections.Generic;
using Entitas;
using UnityEngine;

namespace AbilityMadness.Code.Gameplay.Movement.Systems.Dash
{
    public class DashingCooldownSystem : IExecuteSystem
    {
        private readonly List<GameEntity> _buffer = new(32);
        private IGroup<GameEntity> _dashingEntities;

        public DashingCooldownSystem(GameContext gameContext)
        {
            _dashingEntities = gameContext.GetGroup(GameMatcher
                .AllOf(
                    GameMatcher.DashCooldown));
        }

        public void Execute()
        {
            foreach (var dashingEntity in _dashingEntities.GetEntities(_buffer))
            {
                dashingEntity.DashCooldown -= Time.deltaTime;

                if (dashingEntity.DashCooldown <= 0)
                {
                    dashingEntity.RemoveDashCooldown();
                }
            }
        }
    }
}
