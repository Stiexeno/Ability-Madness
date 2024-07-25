using SF = UnityEngine.SerializeField;

namespace AbilityMadness.Code.Common.Behaviours
{
    public class TransformRegistrar : EntityComponentRegistrar
    {
        [SF] private UnityEngine.Transform _transform;

        public override void RegisterComponents()
        {
            Entity.AddTransform(_transform);
        }

        public override void UnregisterComponents()
        {
            Entity.RemoveTransform();
        }
    }
}
