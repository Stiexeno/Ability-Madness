using SF = UnityEngine.SerializeField;

namespace AbilityMadness.Code.Common.Behaviours
{
    public class Rigidbody2DRegistrar : EntityComponentRegistrar
    {
        [SF] private new UnityEngine.Rigidbody2D rigidbody2D;

        public override void RegisterComponents()
        {
            Entity
                .AddRigidbody2D(rigidbody2D);
        }

        public override void UnregisterComponents()
        {
            if (Entity.hasRigidbody2D)
                Entity.RemoveRigidbody2D();
        }
    }
}
