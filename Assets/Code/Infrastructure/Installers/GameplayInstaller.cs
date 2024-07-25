using AbilityMadness.Code.Infrastructure.Services.Camera;
using AbilityMadness.Infrastructure.Services.Instantiator;
using UnityEngine;
using Zenject;
using SF = UnityEngine.SerializeField;

namespace AbilityMadness
{
	public class GameplayInstaller : MonoInstaller
	{
        [SF] private new Camera camera;

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

            Container.BindInterfacesTo<CameraSetter>()
                .AsSingle()
                .WithArguments(camera);
		}
	}
}
