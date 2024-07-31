using AbilityMadness.Code.Common;
using AbilityMadness.Code.Extensions;
using AbilityMadness.Code.Infrastructure.Services.Physics;
using Entitas;
using UnityEngine;

namespace AbilityMadness.Code.Gameplay.Input.Systems
{
    public class HandleMouseEnterSystem : IExecuteSystem
    {
        private IGroup<GameEntity> _inputs;
        private IPhysicsService _physicsService;
        private ICollisionRegistry _collisionRegistry;

        public HandleMouseEnterSystem(Contexts contexts, IPhysicsService physicsService, ICollisionRegistry collisionRegistry)
        {
            _collisionRegistry = collisionRegistry;
            _physicsService = physicsService;

            _inputs = contexts.game.GetGroup(GameMatcher
                .AllOf(
                    GameMatcher.MousePosition));
        }

        public void Execute()
        {
            foreach (var input in _inputs)
            {
                var hits = _physicsService.RaycastAll(input.MousePosition, Vector3.forward, ~0);
                foreach (var hit in hits)
                {
                    var mouseTriggerEntity = CreateEntity.Empty()
                        .With(x => x.isMouseCollision = true)
                        .With(x => x.isCollisionEnter = true);

                    if (hit != null)
                    {
                        mouseTriggerEntity.AddCollidedId(hit.Id);
                    }
                }
            }
        }
    }
}
