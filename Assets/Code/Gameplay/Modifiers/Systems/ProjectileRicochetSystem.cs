using System.Collections.Generic;
using System.Linq;
using AbilityMadness.Code.Infrastructure.Services.Physics;
using Entitas;

namespace AbilityMadness.Code.Gameplay.Modifiers.Systems.Implemenation.Ricochet
{
    public class ProjectileRicochetSystem : IExecuteSystem
    {
        private const float RicochetDistance = 8f;

        private readonly List<GameEntity> _buffer = new(32);
        private IGroup<GameEntity> _projectiles;
        private IGroup<GameEntity> _targets;
        private IPhysicsService _physicsService;

        public ProjectileRicochetSystem(GameContext gameContext, IPhysicsService physicsService)
        {
            _physicsService = physicsService;
            _projectiles = gameContext.GetGroup(GameMatcher
                .AllOf(
                    GameMatcher.Projectile,
                    GameMatcher.RicochetHitCount,
                    GameMatcher.Direction,
                    GameMatcher.Team,
                    GameMatcher.DamageDealt,
                    GameMatcher.ProccessedTargets));

            _targets = gameContext.GetGroup(GameMatcher
                .AllOf(
                    GameMatcher.Id,
                    GameMatcher.WorldPosition,
                    GameMatcher.Alive,
                    GameMatcher.Team));
        }

        public void Execute()
        {
            foreach (var projectile in _projectiles.GetEntities(_buffer))
            {
                var hits =  _physicsService.CircleCast(
                    projectile.WorldPosition,
                    RicochetDistance,
                    ~0);

                foreach (var hit in hits)
                {
                    if (_targets.ContainsEntity(hit) && hit.Team != projectile.Team && projectile.ProccessedTargets.Last() != hit.Id)
                    {
                        var direction = hit.WorldPosition - projectile.WorldPosition;
                        direction.Normalize();

                        projectile.ReplaceDirection(direction);
                        projectile.RicochetHitCount--;

                        if (projectile.RicochetHitCount <= 0)
                        {
                            projectile.RemoveRicochetHitCount();
                        }

                        break;
                    }
                }
            }
        }
    }
}
