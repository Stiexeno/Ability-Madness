using System;
using AbilityMadness.Code.Infrastructure.Physics;
using UnityEngine;
using Zenject;

namespace AbilityMadness.Code.Infrastructure.View
{
    public class EntityView : MonoBehaviour
    {
        private EntityComponentRegistrar[] _registrars = Array.Empty<EntityComponentRegistrar>();
        private GameEntity _entity;
        private ICollisionRegistry _collisionRegistry;

        public GameEntity Entity => _entity;

        [Inject]
        private void Construct(ICollisionRegistry collisionRegistry)
        {
            _collisionRegistry = collisionRegistry;
        }

        public void LinkEntity(GameEntity entity)
        {
            if (_entity != null && entity == _entity)
                return;

            _entity = entity;
            entity.Retain(this);

            RegisterViewComponents();
        }

        public void ReleaseEntity()
        {
            _entity.Release(this);
            UnregisterViewComponents();
            _entity = null;
        }

        private void RegisterViewComponents()
        {
            _registrars = GetComponents<EntityComponentRegistrar>();

            foreach (var registrar in _registrars)
            {
                registrar.RegisterComponents(_entity);
            }
        }

        private void UnregisterViewComponents()
        {
            foreach (var registrar in _registrars)
            {
                registrar.UnregisterComponents(_entity);
            }
        }
    }
}
