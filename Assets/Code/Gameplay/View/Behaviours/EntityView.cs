using System;
using AbilityMadness.Code.Infrastructure.Services.Physics;
using UnityEngine;
using Zenject;

namespace AbilityMadness.Code.Common.Behaviours
{
    public class EntityView : MonoBehaviour
    {
        private EntityComponentRegistrar[] _registrars = Array.Empty<EntityComponentRegistrar>();
        private GameEntity _entity;
        private ICollisionRegistry _collisionRegistry;

        public string Path { get; set; }

        [Inject]
        private void Construct(ICollisionRegistry collisionRegistry)
        {
            _collisionRegistry = collisionRegistry;
        }

        public void LinkEntity(GameEntity entity)
        {
            _entity = entity;
            RegisterViewComponents();
        }

        private void OnDisable()
        {
            UnregisterViewComponents();
        }

        private void OnDestroy()
        {
            if (_entity != null)
            {
                _entity.Destroy();
            }
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
