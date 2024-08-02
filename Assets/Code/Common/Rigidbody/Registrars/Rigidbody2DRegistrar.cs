using AbilityMadness.Code.Infrastructure.View;
using SF = UnityEngine.SerializeField;

namespace AbilityMadness.Code.Common.Rigidbody.Registrars
{
    [EntityTag("Registrars")]
    public class Rigidbody2DRegistrar : EntityComponentRegistrar
    {
        [SF] private new UnityEngine.Rigidbody2D rigidbody2D;

        public override void RegisterComponents(GameEntity entity)
        {
            entity.AddRigidbody2D(rigidbody2D);
        }

        public override void UnregisterComponents(GameEntity entity)
        {
            if (entity.hasRigidbody2D)
                entity.RemoveRigidbody2D();
        }
    }
}
