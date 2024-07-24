using Zenject;

namespace AbilityMadness
{
    public abstract class AbstractInstaller
    {
        protected DiContainer Container { get; }

        public AbstractInstaller(DiContainer container)
        {
            Container = container;
        }

        public abstract void InstallBindings();
    }
}
