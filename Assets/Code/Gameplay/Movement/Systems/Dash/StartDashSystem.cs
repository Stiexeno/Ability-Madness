using System.Collections.Generic;
using Entitas;

namespace AbilityMadness.Code.Gameplay.Movement.Systems.Dash
{
    public class StartDashSystem : IExecuteSystem
    {
        private readonly List<GameEntity> _buffer = new(32);

        private IGroup<GameEntity> _dashingEntities;

        public StartDashSystem(GameContext gameContext)
        {
            _dashingEntities = gameContext.GetGroup(GameMatcher
                .AllOf(
                    GameMatcher.RequestDash)
                .NoneOf(
                    GameMatcher.Dashing,
                    GameMatcher.DashCooldown));
        }

        public void Execute()
        {
            foreach (var entity in _dashingEntities.GetEntities(_buffer))
            {
                entity.AddDashDuration(0f);
                entity.isDashing = true;
            }
        }
    }
}
