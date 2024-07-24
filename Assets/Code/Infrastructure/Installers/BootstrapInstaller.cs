using AbilityMadness.Infrastructure.Factories.UI;
using AbilityMadness.Infrastructure.Services.Assets;
using AbilityMadness.Infrastructure.Services.Configs;
using AbilityMadness.Infrastructure.Services.Coroutine;
using AbilityMadness.Infrastructure.Services.Instantiator;
using AbilityMadness.Infrastructure.Services.StateMachine;
using AbilityMadness.Infrastructure.Services.StateMachine.Implementations;
using AbilityMadness.Infrastructure.Services.Updatable;
using Zenject;
using SF = UnityEngine.SerializeField;

namespace AbilityMadness
{
	public class BootstrapInstaller : MonoInstaller, IInitializable
	{
		[SF] private CoroutineRunner _coroutineRunner;

		public override void InstallBindings()
		{
			BindServices();
			BindFactories();
		}

		private void BindServices()
		{
            new ECSInstaller(Container).InstallBindings();

			Container.BindInterfacesTo<CoroutineRunner>()
				.FromInstance(_coroutineRunner)
				.AsSingle();

			Container.BindInterfacesAndSelfTo<InstantiatorProvider>()
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
			Container.Resolve<IApplicationStateMachine>().Enter<BootstrapState>();
		}
	}
}
