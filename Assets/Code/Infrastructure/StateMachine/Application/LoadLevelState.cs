using AbilityMadness.Code.Gameplay.Enemy.Waves.Factory;
using AbilityMadness.Code.Gameplay.Projectile.Factory;
using AbilityMadness.Code.Gameplay.Round.Factory;
using AbilityMadness.Code.Gameplay.UI.Hud;
using AbilityMadness.Code.Gameplay.UI.LoadingCurtain;
using AbilityMadness.Code.Gameplay.Upgrades.Services;
using AbilityMadness.Code.Gameplay.Upgrades.UI;
using AbilityMadness.Code.Gameplay.Upgrades.UI.Inventory;
using AbilityMadness.Code.Gameplay.Upgrades.UI.ItemSelection;
using AbilityMadness.Code.Gameplay.Weapons;
using AbilityMadness.Code.Gameplay.Weapons.Factory;
using AbilityMadness.Code.Infrastructure.Scene;
using AbilityMadness.Code.Infrastructure.UI.Factory;
using AbilityMadness.Code.Infrastructure.WorldBuilder.Configs;
using AbilityMadness.Code.Infrastructure.WorldBuilder.Services;
using AbilityMadness.Factory;
using AbilityMadness.Infrastructure.UI;
using Cysharp.Threading.Tasks;
using UnityEngine;
using Zenject;

namespace AbilityMadness.Code.Infrastructure.StateMachine.Application
{
	public class LoadLevelState : IState, IPayloadedEnter<string>
	{
		private ISceneService _sceneService;
		private IUIFactory _uiFactory;
        private IApplicationStateMachine _applicationStateMachine;
        private IPlayerFactory _playerFactory;
        private IUIService _iuiService;
        private ILoadingCurtain _loadingCurtain;
        private IWaveFactory _waveFactory;
        private IWeaponFactory _weaponFactory;
        private IWorldBuilderService _worldBuilderService;
        private IRoundFactory _roundFactory;
        private IProjectileFactory _projectileFactory;
        private IUpgradeService _upgradeService;

        [Inject]
		private void Construct(
			ISceneService sceneService,
			IUIFactory uiFactory,
			IUIService iuiService,
			IApplicationStateMachine applicationStateMachine,
            IPlayerFactory playerFactory,
            ILoadingCurtain loadingCurtain,
            IWaveFactory waveFactory,
            IWeaponFactory weaponFactory,
            IWorldBuilderService worldBuilderService,
            IRoundFactory roundFactory,
            IProjectileFactory projectileFactory,
            IUpgradeService upgradeService)
		{
            _upgradeService = upgradeService;
            _projectileFactory = projectileFactory;
            _roundFactory = roundFactory;
            _worldBuilderService = worldBuilderService;
            _weaponFactory = weaponFactory;
            _waveFactory = waveFactory;
            _loadingCurtain = loadingCurtain;
            _iuiService = iuiService;
            _playerFactory = playerFactory;
            _applicationStateMachine = applicationStateMachine;
            _uiFactory = uiFactory;
			_sceneService = sceneService;
		}

		public void Enter(string sceneName)
		{
            SetupScene().Forget();
		}

        private async UniTask SetupScene()
        {
            await _worldBuilderService.Generate(WorldType.Grassland);
            await LoadAssets();
            await SetupUI();
            CreatePlayer();

            _applicationStateMachine.Enter<BattleLoopState>();
            _loadingCurtain.Hide();
        }

        private async UniTask LoadAssets()
        {
            await _projectileFactory.Load();
        }

		private async UniTask SetupUI()
        {
            await _uiFactory.Load();
			await _uiFactory.CreateUIRoot();
			SetupWindows();
		}

		private void SetupWindows()
		{
            _iuiService.Open<HudWindow>();
            _iuiService.Get<UpgradeSelectionWindow>();
            _iuiService.Get<ItemDescriptionWindow>();
            _iuiService.Get<InventoryWindow>();
            _iuiService.Open<OverlayWindow>();
		}

        private void SetupOverlayWindow()
        {

        }

        private void CreatePlayer()
        {
            var player = _playerFactory.CreatePlayer(Vector3.zero);

            _weaponFactory.CreateWeapon(player, WeaponTypeId.Revolver);

            _waveFactory.CreateWaves();
            _roundFactory.CreateRound(20 * 60);

            _upgradeService.Load();
        }
    }
}
