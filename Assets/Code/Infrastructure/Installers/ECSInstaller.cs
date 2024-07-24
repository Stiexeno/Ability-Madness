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
            Container.BindInterfacesAndSelfTo<Contexts>()
                .FromInstance(Contexts.sharedInstance)
                .AsSingle();

            Container.BindInterfacesTo<SystemFactory>()
                .AsSingle();

            Container.BindInterfacesAndSelfTo<BattleUpdateFeature>()
                .AsSingle();

            Container.BindInterfacesAndSelfTo<BattleFixedUpdateFeature>()
                .AsSingle();

            Container.BindInterfacesAndSelfTo<BattleLateUpdateFeature>()
                .AsSingle();

        }
    }
}
