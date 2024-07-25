using UnityEngine;

namespace AbilityMadness.Code.Common.Behaviours
{
    public abstract class EntityComponentRegistrar : EntityComponent
    {
        protected GameEntity Entity { get; private set; }

        public void LinkEntity(GameEntity entity)
        {
            Entity = entity;
        }

        public abstract void RegisterComponents();
        public abstract void UnregisterComponents();
    }
}
