using AbilityMadness.Code.Common;
using AbilityMadness.Code.Common.Behaviours;
using AbilityMadness.Code.Extensions;
using AbilityMadness.Code.Infrastructure.Services.Physics;
using UnityEngine;
using Zenject;

namespace AbilityMadness.Code.Gameplay.Collision.Behaviours
{
    public class CollisionComponent : EntityComponent
    {
        private ICollisionRegistry _collisionRegistry;
        private Collider2D _collider;

        [Inject]
        private void Construct(ICollisionRegistry collisionRegistry)
        {
            _collisionRegistry = collisionRegistry;
            _collider = GetComponent<Collider2D>();
        }

        public void OnTriggerEnter2D(Collider2D otherCollider)
        {
            var collidedEntity = _collisionRegistry.Get<GameEntity>(otherCollider.GetInstanceID());
            var thisColliderEntity = _collisionRegistry.Get<GameEntity>(_collider.GetInstanceID());

            GameEntity collisionEntity = CreateEntity.Empty()
                .With(x => x.isCollision = true)
                .With(x => x.isTriggerEnter = true);

            if (collidedEntity != null)
                collisionEntity.AddCollidedId(collidedEntity.Id);

            if (thisColliderEntity != null)
                collisionEntity.AddColliderOwnerId(thisColliderEntity.Id);
        }

        public void OnTriggerExit2D(Collider2D otherCollider)
        {
            var collidedEntity = _collisionRegistry.Get<GameEntity>(otherCollider.GetInstanceID());
            var thisColliderEntity = _collisionRegistry.Get<GameEntity>(_collider.GetInstanceID());

            GameEntity collisionEntity = CreateEntity.Empty()
                .With(x => x.isCollision = true)
                .With(x => x.isTriggerExit = true);

            if (collidedEntity != null)
                collisionEntity.AddCollidedId(collidedEntity.Id);

            if (thisColliderEntity != null)
                collisionEntity.AddColliderOwnerId(thisColliderEntity.Id);
        }

        public void OnTriggerStay2D(Collider2D otherCollider)
        {
            var collidedEntity = _collisionRegistry.Get<GameEntity>(otherCollider.GetInstanceID());
            var thisColliderEntity = _collisionRegistry.Get<GameEntity>(_collider.GetInstanceID());

            GameEntity collisionEntity = CreateEntity.Empty()
                .With(x => x.isCollision = true)
                .With(x => x.isTriggerStay = true);

            if (collidedEntity != null)
                collisionEntity.AddCollidedId(collidedEntity.Id);

            if (thisColliderEntity != null)
                collisionEntity.AddColliderOwnerId(thisColliderEntity.Id);
        }

        private void OnCollisionEnter2D(Collision2D other)
        {
            var collidedEntity = _collisionRegistry.Get<GameEntity>(other.collider.GetInstanceID());
            var thisColliderEntity = _collisionRegistry.Get<GameEntity>(_collider.GetInstanceID());

            GameEntity collisionEntity = CreateEntity.Empty()
                .With(x => x.isCollision = true)
                .With(x => x.isCollisionEnter = true);

            if (collidedEntity != null)
                collisionEntity.AddCollidedId(collidedEntity.Id);

            if (thisColliderEntity != null)
                collisionEntity.AddColliderOwnerId(thisColliderEntity.Id);
        }

        private void OnCollisionExit2D(Collision2D other)
        {
            var collidedEntity = _collisionRegistry.Get<GameEntity>(other.collider.GetInstanceID());
            var thisColliderEntity = _collisionRegistry.Get<GameEntity>(_collider.GetInstanceID());

            GameEntity collisionEntity = CreateEntity.Empty()
                .With(x => x.isCollision = true)
                .With(x => x.isCollisionExit = true);

            if (collidedEntity != null)
                collisionEntity.AddCollidedId(collidedEntity.Id);

            if (thisColliderEntity != null)
                collisionEntity.AddColliderOwnerId(thisColliderEntity.Id);
        }

        private void OnCollisionStay2D(Collision2D other)
        {
            var collidedEntity = _collisionRegistry.Get<GameEntity>(other.collider.GetInstanceID());
            var thisColliderEntity = _collisionRegistry.Get<GameEntity>(_collider.GetInstanceID());

            GameEntity collisionEntity = CreateEntity.Empty()
                .With(x => x.isCollision = true)
                .With(x => x.isCollisionStay = true);

            if (collidedEntity != null)
                collisionEntity.AddCollidedId(collidedEntity.Id);

            if (thisColliderEntity != null)
                collisionEntity.AddColliderOwnerId(thisColliderEntity.Id);
        }
    }
}
