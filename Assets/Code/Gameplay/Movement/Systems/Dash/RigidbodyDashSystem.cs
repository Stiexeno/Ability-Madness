using System.Collections.Generic;
using Entitas;
using UnityEngine;

namespace AbilityMadness.Code.Gameplay.Movement.Systems.Dash
{
    public class RigidbodyDashSystem : IExecuteSystem
    {
        private const float dashForce = 15f;
        private const float dashDuration = 0.15f;

        private readonly List<GameEntity> _buffer = new(32);

        private IGroup<GameEntity> _dashingEntities;

        public RigidbodyDashSystem(GameContext gameContext)
        {
            _dashingEntities = gameContext.GetGroup(GameMatcher
                .AllOf(
                    GameMatcher.Dashing,
                    GameMatcher.Rigidbody2D,
                    GameMatcher.RigidbodyMovement,
                    GameMatcher.Direction));
        }

        public void Execute()
        {
            foreach (var entity in _dashingEntities.GetEntities(_buffer))
            {
                entity.DashDuration += Time.deltaTime;

                var direction = entity.Direction * dashForce;
                entity.Rigidbody2D.velocity = direction;

                if (entity.DashDuration >= dashDuration)
                {
                    entity.isDashing = false;
                    entity.RemoveDashDuration();
                    entity.AddDashCooldown(1f);
                }
            }
        }
    }
}
