using AbilityMadness.Code.Infrastructure.View;
using SF = UnityEngine.SerializeField;

namespace AbilityMadness.Code.Common.Transform.Registrars
{
    [EntityTag("Registrars")]
    public class HeadRegistrar : EntityComponentRegistrar
    {
        [SF] private UnityEngine.Transform head;

        public override void RegisterComponents(GameEntity entity)
        {
            entity.AddHead(head);
        }

        public override void UnregisterComponents(GameEntity entity)
        {
            entity.RemoveHead();
        }
    }
}
