using AbilityMadness.Code.Gameplay.Camera.Factory;
using AbilityMadness.Code.Gameplay.Chest.Factory;
using AbilityMadness.Code.Infrastructure.Services.Camera;
using AbilityMadness.Code.Infrastructure.Services.Cursors;
using AbilityMadness.Code.Infrastructure.Services.Identifiers;
using AbilityMadness.Code.Infrastructure.Services.Physics;
using AbilityMadness.Code.Infrastructure.Services.View;
using AbilityMadness.Factory;
using AbilityMadness.Infrastructure.Factories.UI;
using AbilityMadness.Infrastructure.Services.Assets;
using AbilityMadness.Infrastructure.Services.Configs;
using AbilityMadness.Infrastructure.Services.Coroutine;
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

            Container.BindInterfacesTo<PlayerFactory>()
                .AsSingle();

            Container.BindInterfacesTo<ChestFactory>()
                .AsSingle();

            Container.BindInterfacesTo<ViewPool>()
                .AsSingle();

            Container.BindInterfacesAndSelfTo<PlayerInput>()
                .FromInstance(playerInput)
                .AsSingle();

            Container.BindInterfacesTo<CameraFactory>()
                .AsSingle();

            Container.BindInterfacesTo<CollisionRegistry>()
                .AsSingle();

            Container.BindInterfacesTo<PhysicsService>()
                .AsSingle();

            Container.BindInterfacesTo<CursorService>()
                .AsSingle()
                .NonLazy();
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
				.AsSingle();

			Container.BindInterfacesTo<StatesFactory>()
				.AsSingle();
		}

		public void Initialize()
		{
			Container.Resolve<IApplicationStateMachine>().Enter<BootstrapState>().Forget();
		}
	}
}
