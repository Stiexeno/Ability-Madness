using AbilityMadness.Code.Common.Behaviours;
using AbilityMadness.Code.Infrastructure.Services.Physics;
using UnityEngine;
using Zenject;

namespace AbilityMadness.Code.Gameplay.Collision.Registrars
{
    public class CollidersRegistrar : EntityComponentRegistrar
    {
        private Collider2D[] _colliders;
        private ICollisionRegistry _collisionRegistry;

        [Inject]
        private void Construct(ICollisionRegistry collisionRegistry)
        {
            _collisionRegistry = collisionRegistry;
        }

        public override void RegisterComponents(GameEntity entity)
        {
            _colliders = GetComponentsInChildren<Collider2D>();

            foreach (var col in _colliders)
            {
                _collisionRegistry.Register(col.GetInstanceID(), entity);
            }
        }

        public override void UnregisterComponents(GameEntity entity)
        {
            foreach (var col in _colliders)
            {
                _collisionRegistry.Unregister(col.GetInstanceID());
            }
        }
    }
}
