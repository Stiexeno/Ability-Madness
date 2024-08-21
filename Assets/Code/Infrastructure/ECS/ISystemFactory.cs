using Entitas;

namespace AbilityMadness.Code.Infrastructure.ECS
{
    public interface ISystemFactory
    {
        T Create<T>() where T : ISystem;
    }
}
