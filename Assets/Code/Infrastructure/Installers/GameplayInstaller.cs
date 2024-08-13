using AbilityMadness.Code.Common.Factory;
using AbilityMadness.Code.Gameplay.Camera.Factory;
using AbilityMadness.Code.Gameplay.Chest.Factory;
using AbilityMadness.Code.Gameplay.EffectApplication.Factory;
using AbilityMadness.Code.Gameplay.Enemy.Factory;
using AbilityMadness.Code.Gameplay.Enemy.Waves.Factory;
using AbilityMadness.Code.Gameplay.Experience.Factory;
using AbilityMadness.Code.Gameplay.Modifiers.Factory;
using AbilityMadness.Code.Gameplay.Projectile.Factory;
using AbilityMadness.Code.Gameplay.Round.Factory;
using AbilityMadness.Code.Gameplay.Stats.Factory;
using AbilityMadness.Code.Gameplay.Weapons.Bullets.Factory;
using AbilityMadness.Code.Gameplay.Weapons.Factory;
using AbilityMadness.Code.Infrastructure.Services.Assembler;
using AbilityMadness.Code.Infrastructure.Services.Assembler.Installer;
using AbilityMadness.Code.Infrastructure.Services.Camera;
using AbilityMadness.Code.Infrastructure.Services.Camera.Shake;
using AbilityMadness.Code.Infrastructure.Services.View;
using AbilityMadness.Code.Infrastructure.Services.WorldBuilder.Services;
using AbilityMadness.Factory;
using AbilityMadness.Infrastructure.Services.Instantiator;
using UnityEngine;
using UnityEngine.Tilemaps;
using Zenject;
using SF = UnityEngine.SerializeField;

namespace AbilityMadness
{
	public class GameplayInstaller : MonoInstaller
	{
        [SF] private new Camera camera;
        [SF] private Tilemap[] tilemaps;

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

            Container.BindInterfacesTo<ShakeService>()
                .AsSingle()
                .WithArguments(camera);

            Container.BindInterfacesTo<WorldBuilderService>()
                .AsSingle()
                .WithArguments(tilemaps);
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

            Container.BindInterfacesTo<PlayerFactory>()
                .AsSingle();

            Container.BindInterfacesTo<WaveFactory>()
                .AsSingle();

            Container.BindInterfacesTo<ModifierFactory>()
                .AsSingle();

            Container.BindInterfacesTo<WeaponFactory>()
                .AsSingle();

            Container.BindInterfacesTo<BulletFactory>()
                .AsSingle();

            Container.BindInterfacesTo<RoundFactory>()
                .AsSingle();

            Container.BindInterfacesTo<StatsFactory>()
                .AsSingle();

            Container.BindInterfacesTo<ViewFactory>()
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
