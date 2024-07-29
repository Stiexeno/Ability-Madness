using AbilityMadness.Code.Common;
using AbilityMadness.Code.Extensions;
using AbilityMadness.Code.Infrastructure.Services.Physics;
using Entitas;
using UnityEngine;

namespace AbilityMadness.Code.Gameplay.Input.Systems
{
    public class HandleMouseExitSystem : IExecuteSystem
    {
        private IGroup<GameEntity> _mouseInHovers;
        private IGroup<GameEntity> _inputs;

        private IPhysicsService _physicsService;
        private ICollisionRegistry _collisionRegistry;

        public HandleMouseExitSystem(Contexts contexts, IPhysicsService physicsService, ICollisionRegistry collisionRegistry)
        {
            _collisionRegistry = collisionRegistry;
            _physicsService = physicsService;

            _mouseInHovers = contexts.game.GetGroup(GameMatcher
                .AllOf(
                    GameMatcher.MouseInHover,
                    GameMatcher.Id));

            _inputs = contexts.game.GetGroup(GameMatcher
                .AllOf(
                    GameMatcher.MousePosition));
        }

        public void Execute()
        {
            foreach (var input in _inputs)
            {
                var hits = _physicsService.RaycastAll(input.MousePosition, Vector3.forward, ~0);

                foreach (var mouseHover in _mouseInHovers)
                {
                    var inHover = false;

                    foreach (var hit in hits)
                    {
                        var collidedEntity = _collisionRegistry.Get<GameEntity>(hit.Collider2D.GetInstanceID());

                        if (collidedEntity == mouseHover)
                        {
                            inHover = true;
                            break;
                        }
                    }

                    if (inHover == false)
                    {
                        var mouseTriggerEntity = CreateEntity.Empty()
                            .With(x => x.isMouseCollision = true)
                            .With(x => x.isCollisionExit = true);

                        mouseTriggerEntity.AddCollidedId(mouseHover.Id);
                    }
                }
            }
        }
    }
}
