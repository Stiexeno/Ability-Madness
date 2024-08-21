using AbilityMadness.Code.Infrastructure.ECS;
using AbilityMadness.Code.Infrastructure.ECS.Battle;
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

            Container.BindInterfacesAndSelfTo<GameContext>()
                .FromInstance(Contexts.sharedInstance.game)
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
