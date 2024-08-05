using AbilityMadness.Code.Gameplay.Camera.Factory;
using AbilityMadness.Code.Gameplay.Chest.Factory;
using AbilityMadness.Code.Gameplay.EffectApplication.Factory;
using AbilityMadness.Code.Gameplay.Enemy.Factory;
using AbilityMadness.Code.Gameplay.Experience.Factory;
using AbilityMadness.Code.Gameplay.Projectile.Factory;
using AbilityMadness.Code.Infrastructure.Services.Assembler;
using AbilityMadness.Code.Infrastructure.Services.Assembler.Installer;
using AbilityMadness.Code.Infrastructure.Services.Camera;
using AbilityMadness.Code.Infrastructure.Services.View;
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
			BindSetters();
			BindServices();
            BindFactories();
            BindInstallers();

		}

		private void BindServices()
        {
            Container.BindInterfacesTo<ViewPool>()
                .AsSingle();
        }

        private void BindFactories()
        {
            Container.BindInterfacesTo<VFXFactory>()
                .AsSingle();

            Container.BindInterfacesTo<ProjectileFactory>()
                .AsSingle();

            Container.BindInterfacesTo<ChestFactory>()
                .AsSingle();

            Container.BindInterfacesTo<CameraFactory>()
                .AsSingle();

            Container.BindInterfacesTo<EnemyFactory>()
                .AsSingle();

            Container.BindInterfacesTo<ExperienceFactory>()
                .AsSingle();
        }

        private void BindInstallers()
        {
            Container.BindInterfacesTo<AttachmentFacade>()
                .FromSubContainerResolve()
                .ByInstaller<AttachmentInstaller>()
                .WithKernel()
                .AsSingle()
                .NonLazy();
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
