﻿using AbilityMadness.Code.Infrastructure.Physics;
using Entitas;

namespace AbilityMadness.Code.Gameplay.TargetCollection.Systems
{
    public class CollectTargetsWithSphereCastSystem : IExecuteSystem
    {
        private IGroup<GameEntity> _targetCollectors;
        private IPhysicsService _physicsService;
        private IGroup<GameEntity> _targets;

        public CollectTargetsWithSphereCastSystem(Contexts contexts, IPhysicsService physicsService)
        {
            _physicsService = physicsService;
            _targetCollectors = contexts.game.GetGroup(GameMatcher
                .AllOf(
                    GameMatcher.TargetBuffer,
                    GameMatcher.ProccessedTargets,
                    GameMatcher.WorldPosition,
                    GameMatcher.SphereCast,
                    GameMatcher.SphereCastRadius,
                    GameMatcher.Team));

            _targets = contexts.game.GetGroup(GameMatcher
                .AllOf(
                    GameMatcher.Id,
                    GameMatcher.Team));
        }

        public void Execute()
        {
            foreach (var targetCollector in _targetCollectors)
            {
               var hits =  _physicsService.CircleCast(
                   targetCollector.WorldPosition,
                   targetCollector.SphereCastRadius,
                   1 << Layers.TeamToLayer[targetCollector.Team]);

               foreach (var hit in hits)
               {
                   if (_targets.ContainsEntity(hit) && targetCollector.ProccessedTargets.Contains(hit.Id) == false)
                   {
                       targetCollector.TargetBuffer.Add(hit.Id);
                       targetCollector.ProccessedTargets.Add(hit.Id);
                   }
               }
            }
        }
    }
}
