using AbilityMadness.Code.Infrastructure.Services.Physics;
using AbilityMadness.Code.Infrastructure.View;
using UnityEngine;
using Zenject;
using SF = UnityEngine.SerializeField;

namespace AbilityMadness.Code.Common.Collision.Registrars
{
    [EntityTag("Registrars")]
    public class CollidersRegistrar : EntityComponentRegistrar
    {
        [SF] private Collider2D[] colliders;

        private ICollisionRegistry _collisionRegistry;

        [Inject]
        private void Construct(ICollisionRegistry collisionRegistry)
        {
            _collisionRegistry = collisionRegistry;
        }

        public override void RegisterComponents(GameEntity entity)
        {
            entity.AddCollider2D(colliders[0]);

            foreach (var col in colliders)
            {
                _collisionRegistry.Register(col.GetInstanceID(), entity);
            }
        }

        public override void UnregisterComponents(GameEntity entity)
        {
            foreach (var col in colliders)
            {
                _collisionRegistry.Unregister(col.GetInstanceID());
            }
        }
    }
}
