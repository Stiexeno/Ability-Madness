using AbilityMadness.Infrastructure.Services.Instantiator;
using Zenject;

namespace AbilityMadness
{
	public class BootSceneInstaller : MonoInstaller
	{
		public override void InstallBindings()
		{
			BindSetters();
		}
		
		private void BindSetters()
		{
			Container.BindInterfacesTo<InstantiatorSetter>()
				.AsSingle();
		}
	}
}