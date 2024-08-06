using System.Collections.Generic;
using AbilityMadness.Code.Infrastructure.Services.Physics;
using Entitas;

namespace AbilityMadness.Code.Gameplay.Modifiers.Systems.Implemenation.Ricochet
{
    public class ProjectileRicochetSystem : IExecuteSystem
    {
        private const float RicochetDistance = 8f;

        private readonly List<GameEntity> _buffer = new(32);
        private IGroup<GameEntity> _producedEntities;
        private IGroup<GameEntity> _targets;
        private IPhysicsService _physicsService;

        public ProjectileRicochetSystem(GameContext gameContext, IPhysicsService physicsService)
        {
            _physicsService = physicsService;
            _producedEntities = gameContext.GetGroup(GameMatcher
                .AllOf(
                    GameMatcher.ProducedByAbility,
                    GameMatcher.Ricochet,
                    GameMatcher.RicochetHitCount,
                    GameMatcher.Direction,
                    GameMatcher.Team,
                    GameMatcher.DamageDealt));

            _targets = gameContext.GetGroup(GameMatcher
                .AllOf(
                    GameMatcher.Id,
                    GameMatcher.WorldPosition,
                    GameMatcher.Alive,
                    GameMatcher.Team));
        }

        public void Execute()
        {
            foreach (var producedEntity in _producedEntities.GetEntities(_buffer))
            {
                var hits =  _physicsService.CircleCast(
                    producedEntity.WorldPosition,
                    RicochetDistance,
                    ~0);

                foreach (var hit in hits)
                {
                    if (_targets.ContainsEntity(hit) && hit.Team != producedEntity.Team)
                    {
                        var direction = hit.WorldPosition - producedEntity.WorldPosition;
                        direction.Normalize();

                        producedEntity.ReplaceDirection(direction);
                        producedEntity.RicochetHitCount--;

                        if (producedEntity.RicochetHitCount <= 0)
                        {
                            producedEntity.isRicochet = false;
                        }

                        break;
                    }
                }
            }
        }
    }
}
