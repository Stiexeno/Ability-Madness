using AbilityMadness.Code.Infrastructure.Instantiator;
using Entitas;
using Zenject;

namespace AbilityMadness.Code.Infrastructure.ECS
{
    public class SystemFactory : ISystemFactory
    {
        private IInstantiator _instantiator;

        public SystemFactory(InstantiatorProvider instantiatorProvider)
        {
            _instantiator = instantiatorProvider.Instantiator;
        }

        public T Create<T>() where T : ISystem => _instantiator.Instantiate<T>();
    }
}
