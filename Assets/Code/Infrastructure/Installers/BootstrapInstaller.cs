using AbilityMadness.Code.Gameplay.Experience.Services;
using AbilityMadness.Code.Gameplay.UI.Factory;
using AbilityMadness.Code.Infrastructure.Assets;
using AbilityMadness.Code.Infrastructure.Camera;
using AbilityMadness.Code.Infrastructure.Configs;
using AbilityMadness.Code.Infrastructure.Coroutine;
using AbilityMadness.Code.Infrastructure.Cursors;
using AbilityMadness.Code.Infrastructure.Services.Identifiers;
using AbilityMadness.Code.Infrastructure.Services.Physics;
using AbilityMadness.Code.Infrastructure.Services.TimeService;
using AbilityMadness.Code.Infrastructure.Services.UI;
using AbilityMadness.Infrastructure.Factories.UI;
using AbilityMadness.Infrastructure.Services.Instantiator;
using AbilityMadness.Infrastructure.Services.StateMachine;
using AbilityMadness.Infrastructure.Services.StateMachine.Implementations;
using AbilityMadness.Infrastructure.Services.Updatable;
using Cysharp.Threading.Tasks;
using UnityEngine.InputSystem;
using Zenject;
using SF = UnityEngine.SerializeField;

namespace AbilityMadness
{
	public class BootstrapInstaller : MonoInstaller, IInitializable
	{
		[SF] private LoadingCurtain loadingCurtain;
		[SF] private CoroutineRunner coroutineRunner;
		[SF] private PlayerInput playerInput;

		public override void InstallBindings()
		{
			BindServices();
			BindFactories();
            BindProviders();
		}

		private void BindServices()
		{
            new ECSInstaller(Container).InstallBindings();

			Container.BindInterfacesTo<CoroutineRunner>()
				.FromInstance(coroutineRunner)
				.AsSingle();

            Container.BindInterfacesTo<IdentifierService>()
                .AsSingle();

			Container.BindInterfacesTo<BootstrapInstaller>()
				.FromInstance(this)
				.AsSingle();

			Container.BindInterfacesTo<ApplicationStateMachine>()
				.AsSingle();

			Container.BindInterfacesTo<SceneService>()
				.AsSingle();

			Container.BindInterfacesTo<UIService>()
				.AsSingle();

			Container.BindInterfacesTo<Assets>()
				.AsSingle();

			Container.BindInterfacesTo<ConfigsService>()
				.AsSingle();

			Container.BindInterfacesTo<UpdateService>()
				.AsSingle();

            Container.BindInterfacesAndSelfTo<PlayerInput>()
                .FromInstance(playerInput)
                .AsSingle();

            Container.BindInterfacesTo<CollisionRegistry>()
                .AsSingle();

            Container.BindInterfacesTo<PhysicsService>()
                .AsSingle();

            Container.BindInterfacesTo<CursorService>()
                .AsSingle()
                .NonLazy();

            Container.BindInterfacesTo<LoadingCurtain>()
                .FromInstance(loadingCurtain)
                .AsSingle();

            Container.BindInterfacesTo<ExperienceCalculatorService>()
                .AsSingle();

            Container.BindInterfacesTo<TimeService>()
                .AsSingle();
        }

        private void BindProviders()
        {
            Container.BindInterfacesAndSelfTo<InstantiatorProvider>()
                .AsSingle();

            Container.BindInterfacesAndSelfTo<CameraProvider>()
                .AsSingle();
        }

        private void BindFactories()
        {
            Container.BindInterfacesTo<UIFactory>()
                .AsSingle()
                .NonLazy();

            Container.BindInterfacesTo<UIPool>()
                .AsSingle();

			Container.BindInterfacesTo<StatesFactory>()
				.AsSingle();

            Container.BindInterfacesTo<UIEntityFactory>()
                .AsSingle();
		}

		public void Initialize()
		{
			Container.Resolve<IApplicationStateMachine>().Enter<BootstrapState>().Forget();
		}
	}
}
