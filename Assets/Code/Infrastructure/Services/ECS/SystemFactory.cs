using Entitas;
using Zenject;

namespace AbilityMadness.Code.Infrastructure.Services.ECS
{
    public class SystemFactory : ISystemFactory
    {
        private IInstantiator _instantiator;

        public SystemFactory(IInstantiator instantiator)
        {
            _instantiator = instantiator;
        }

        public T Create<T>() where T : ISystem => _instantiator.Instantiate<T>();
    }
}
