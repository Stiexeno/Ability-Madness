namespace AbilityMadness.Code.Common.Behaviours
{
    public class TransformRegistrar : EntityComponentRegistrar
    {
        public override void RegisterComponents(GameEntity entity)
        {
            entity.AddTransform(transform);
        }

        public override void UnregisterComponents(GameEntity entity)
        {
            if (entity.hasTransform)
                entity.RemoveTransform();
        }
    }
}
