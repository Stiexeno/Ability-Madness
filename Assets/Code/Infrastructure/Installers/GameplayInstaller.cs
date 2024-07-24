using AbilityMadness.Infrastructure.Services.Instantiator;
using Zenject;
using SF = UnityEngine.SerializeField;

namespace AbilityMadness
{
	public class GameplayInstaller : MonoInstaller
	{
		public override void InstallBindings()
		{
			BindServices();
			BindSetters();
		}

		private void BindServices()
		{

		}

		private void BindSetters()
		{
			Container.BindInterfacesTo<InstantiatorSetter>()
				.AsSingle();
		}
	}
}
