using AbilityMadness.Code.Infrastructure.View;

namespace AbilityMadness.Code.Common.Transform.Registrars
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
