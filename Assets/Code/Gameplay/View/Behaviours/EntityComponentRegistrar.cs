namespace AbilityMadness.Code.Common.Behaviours
{
    public abstract class EntityComponentRegistrar : EntityComponent
    {
        public abstract void RegisterComponents(GameEntity entity);
        public abstract void UnregisterComponents(GameEntity entity);
    }
}
