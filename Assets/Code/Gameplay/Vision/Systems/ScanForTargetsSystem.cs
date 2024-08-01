using System.Linq;
using AbilityMadness.Code.Infrastructure.Services.Physics;
using Entitas;
using UnityEngine;

namespace AbilityMadness.Code.Gameplay.Vision.Systems
{
    public class ScanForTargetsSystem : IExecuteSystem
    {
        private IGroup<GameEntity> _visionEntities;
        private IPhysicsService _physicsService;
        private IGroup<GameEntity> _targets;
        private GameContext _gameContext;

        public ScanForTargetsSystem(GameContext gameContext, IPhysicsService physicsService)
        {
            _gameContext = gameContext;
            _physicsService = physicsService;
            _visionEntities = gameContext.GetGroup(GameMatcher
                .AllOf(
                    GameMatcher.Vision,
                    GameMatcher.VisionRadius,
                    GameMatcher.VisionLayer,
                    GameMatcher.TargetsInSight,
                    GameMatcher.VisionInterval,
                    GameMatcher.VisionTimer,
                    GameMatcher.WorldPosition));

            _targets = gameContext.GetGroup(GameMatcher
                .AllOf(
                    GameMatcher.Id,
                    GameMatcher.WorldPosition));
        }

        public void Execute()
        {
            foreach (var visionEntity in _visionEntities)
            {
                // if (visionEntity.VisionTimer > 0)
                // {
                //     visionEntity.VisionTimer -= Time.deltaTime;
                //     continue;
                // }
                //
                // visionEntity.VisionTimer = visionEntity.VisionInterval;

                ScanForTargets(visionEntity);
            }
        }

        private void ScanForTargets(GameEntity visionEntity)
        {
            var hits = _physicsService.CircleCast(
                visionEntity.WorldPosition,
                visionEntity.VisionRadius,
                1 << visionEntity.VisionLayer);

            foreach (var hit in hits)
            {
                if (_targets.ContainsEntity(hit) == false)
                    continue;

                visionEntity.TargetsInSight.Add(hit.Id);
            }
        }
    }
}
