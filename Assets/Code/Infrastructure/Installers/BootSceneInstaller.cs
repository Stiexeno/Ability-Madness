using AbilityMadness.Code.Infrastructure.Camera;
using AbilityMadness.Code.Infrastructure.Instantiator;
using UnityEngine;
using Zenject;
using SF = UnityEngine.SerializeField;

namespace AbilityMadness
{
	public class BootSceneInstaller : MonoInstaller
    {
        [SF] private new Camera camera;

		public override void InstallBindings()
		{
			BindSetters();
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
