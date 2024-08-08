﻿using AbilityMadness.Code.Gameplay.Abilities;
using AbilityMadness.Code.Gameplay.Abilities.Factory;
using AbilityMadness.Code.Gameplay.Enemy.Waves.Factory;
using AbilityMadness.Code.Gameplay.Weapons;
using AbilityMadness.Code.Gameplay.Weapons.Factory;
using AbilityMadness.Code.Infrastructure.Services.WorldBuilder.Configs;
using AbilityMadness.Code.Infrastructure.Services.WorldBuilder.Services;
using AbilityMadness.Factory;
using AbilityMadness.Infrastructure.Factories.UI;
using Cysharp.Threading.Tasks;
using UnityEngine;
using UnityEngine.SceneManagement;
using Zenject;

namespace AbilityMadness.Infrastructure.Services.StateMachine.Implementations
{
	public class LoadLevelState : IState, IPayloadedEnter<string>
	{
		private ISceneService _sceneService;
		private IUIFactory _uiFactory;
        private IApplicationStateMachine _applicationStateMachine;
        private IPlayerFactory _playerFactory;
        private IUIService _iuiService;
        private IAbilityFactory _abilityFactory;
        private ILoadingCurtain _loadingCurtain;
        private IWaveFactory _waveFactory;
        private IWeaponFactory _weaponFactory;
        private IWorldBuilderService _worldBuilderService;

        [Inject]
		private void Construct(
			ISceneService sceneService,
			IUIFactory uiFactory,
			IUIService iuiService,
			IApplicationStateMachine applicationStateMachine,
            IPlayerFactory playerFactory,
            IAbilityFactory abilityFactory,
            ILoadingCurtain loadingCurtain,
            IWaveFactory waveFactory,
            IWeaponFactory weaponFactory,
            IWorldBuilderService worldBuilderService)
		{
            _worldBuilderService = worldBuilderService;
            _weaponFactory = weaponFactory;
            _waveFactory = waveFactory;
            _loadingCurtain = loadingCurtain;
            _abilityFactory = abilityFactory;
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
            await SetupUI();
            CreatePlayer();

            _applicationStateMachine.Enter<BattleLoopState>();
            _loadingCurtain.Hide();
        }

		private async UniTask SetupUI()
		{
			await _uiFactory.CreateUIRoot();
			SetupWindows();
		}

		private void SetupWindows()
		{
            _iuiService.Open<HudWindow>();
		}

        private void CreatePlayer()
        {
            var player = _playerFactory.CreatePlayer(Vector3.zero);
            _abilityFactory.CreateAbility(player, AbilityTypeId.Fireball);

            _weaponFactory.CreateWeapon(player, WeaponTypeId.Revolver);

            _waveFactory.CreateWave();
        }
    }
}
