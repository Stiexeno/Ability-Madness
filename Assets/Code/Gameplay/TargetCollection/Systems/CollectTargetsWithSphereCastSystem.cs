using AbilityMadness.Code.Infrastructure.Services.Physics;
using Entitas;

namespace AbilityMadness.Code.Gameplay.TargetCollection.Systems
{
    public class CollectTargetsWithSphereCastSystem : IExecuteSystem
    {
        private IGroup<GameEntity> _targetCollectors;
        private IPhysicsService _physicsService;

        public CollectTargetsWithSphereCastSystem(Contexts contexts, IPhysicsService physicsService)
        {
            _physicsService = physicsService;
            _targetCollectors = contexts.game.GetGroup(GameMatcher
                .AllOf(
                    GameMatcher.TargetBuffer,
                    GameMatcher.ProccessedTargets,
                    GameMatcher.WorldPosition,
                    GameMatcher.SphereCast,
                    GameMatcher.SphereCastRadius));
        }

        public void Execute()
        {
            foreach (var targetCollector in _targetCollectors)
            {
               var hits =  _physicsService.CircleCast(
                   targetCollector.WorldPosition,
                   targetCollector.SphereCastRadius,
                   ~0);

               foreach (var hit in hits)
               {
                   if (hit.hasId && targetCollector.ProccessedTargets.Contains(hit.Id) == false)
                   {
                       targetCollector.TargetBuffer.Add(hit.Id);
                       targetCollector.ProccessedTargets.Add(hit.Id);
                   }
               }
            }
        }
    }
}
