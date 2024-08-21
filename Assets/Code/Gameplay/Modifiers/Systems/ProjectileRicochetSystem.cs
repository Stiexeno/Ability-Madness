using System.Collections.Generic;
using System.Linq;
using AbilityMadness.Code.Infrastructure.Physics;
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
        private IGroup<GameEntity> _entities;
        private GameContext _gameContext;

        public ProjectileRicochetSystem(GameContext gameContext, IPhysicsService physicsService)
        {
            _gameContext = gameContext;
            _physicsService = physicsService;
            _projectiles = gameContext.GetGroup(GameMatcher
                .AllOf(
                    GameMatcher.Projectile,
                    GameMatcher.RicochetHitCount,
                    GameMatcher.Direction,
                    GameMatcher.Team,
                    GameMatcher.ProccessedTargets));

            _targets = gameContext.GetGroup(GameMatcher
                .AllOf(
                    GameMatcher.Id,
                    GameMatcher.WorldPosition,
                    GameMatcher.Alive,
                    GameMatcher.Team));

           _entities = gameContext.GetGroup(GameMatcher
               .AllOf(
                   GameMatcher.EffectDealt));
        }

        public void Execute()
        {
            foreach (var entity in _entities)
            {
                var projectile = _gameContext.GetEntityWithId(entity.EffectDealt);

                if (_projectiles.ContainsEntity(projectile))
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
}
