namespace AbilityMadness.Code.Infrastructure.View
{
    public abstract class EntityComponentRegistrar : EntityComponent
    {
        public abstract void RegisterComponents(GameEntity entity);
        public abstract void UnregisterComponents(GameEntity entity);
    }
}
