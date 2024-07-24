using AbilityMadness.Code.Infrastructure.Services.ECS;
using Zenject;

namespace AbilityMadness
{
    public class ECSInstaller : AbstractInstaller
    {
        public ECSInstaller(DiContainer container) : base(container)
        {
        }

        public override void InstallBindings()
        {
            Container.BindInterfacesTo<ECSFacade>()
                .AsSingle();

            Container.BindInterfacesAndSelfTo<Contexts>()
                .FromInstance(new Contexts())
                .AsSingle();

            Container.BindInterfacesTo<SystemFactory>()
                .AsSingle();

            Container.BindInterfacesAndSelfTo<UpdateSystems>()
                .AsSingle();

            Container.BindInterfacesAndSelfTo<FixedUpdateSystems>()
                .AsSingle();

            Container.BindInterfacesAndSelfTo<LateUpdateSystems>()
                .AsSingle();

        }
    }
}
