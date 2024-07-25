using System;
using UnityEngine;

namespace AbilityMadness.Code.Common.Behaviours
{
    public class EntityView : MonoBehaviour
    {
        private EntityComponentRegistrar[] _registrars = Array.Empty<EntityComponentRegistrar>();
        private GameEntity _entity;

        public string Path { get; set; }

        public void LinkEntity(GameEntity entity)
        {
            _entity = entity;
            RegisterViewComponents();
        }

        private void OnDisable()
        {
            UnregisterViewComponents();
        }

        private void RegisterViewComponents()
        {
            _registrars = GetComponents<EntityComponentRegistrar>();

            foreach (var registrar in _registrars)
            {
                registrar.LinkEntity(_entity);
                registrar.RegisterComponents();
            }
        }

        private void UnregisterViewComponents()
        {
            foreach (var registrar in _registrars)
            {
                registrar.UnregisterComponents();
            }
        }
    }
}
