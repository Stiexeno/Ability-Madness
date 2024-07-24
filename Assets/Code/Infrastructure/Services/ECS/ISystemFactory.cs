using Entitas;

namespace AbilityMadness.Code.Infrastructure.Services.ECS
{
    public interface ISystemFactory
    {
        T Create<T>() where T : ISystem;
    }
}
