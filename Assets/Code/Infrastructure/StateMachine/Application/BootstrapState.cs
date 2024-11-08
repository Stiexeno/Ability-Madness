﻿using AbilityMadness.Code.Gameplay.UI.LoadingCurtain;
using AbilityMadness.Code.Infrastructure.Assets;
using AbilityMadness.Code.Infrastructure.Scene;
using Cysharp.Threading.Tasks;
using UnityEngine.SceneManagement;
using Zenject;

namespace AbilityMadness.Code.Infrastructure.StateMachine.Application
{
	public class BootstrapState : IState, IEnter
	{
		private IApplicationStateMachine _applicationStateMachine;
		private ISceneService _sceneService;
		private IAssets _assets;
        private ILoadingCurtain _loadingCurtain;

        private const int TARGET_FRAME_RATE = 120;

		[Inject]
		private void Construct(
			IApplicationStateMachine applicationStateMachine,
			ISceneService sceneService,
			IAssets assets,
            ILoadingCurtain loadingCurtain)
		{
            _loadingCurtain = loadingCurtain;
            _assets = assets;
			_sceneService = sceneService;
			_applicationStateMachine = applicationStateMachine;
		}

		public void Enter()
		{
			SetTargetFrameRate();

			_assets.Initialize();
			_sceneService.Load(Scenes.BootSceneName, EnterLoadedScene);
		}

		private static void SetTargetFrameRate()
		{
			UnityEngine.Application.targetFrameRate = TARGET_FRAME_RATE;
		}

		private void EnterLoadedScene()
		{
            _loadingCurtain.Show();
            var currentActiveScene = SceneManager.GetActiveScene().name;

            if (currentActiveScene != Scenes.GameplaySceneName)
            {
                _sceneService.Load(Scenes.GameplaySceneName, onLoaded: OnSceneLoaded);
            }
            else
            {
                OnSceneLoaded();
            }
		}

        private void OnSceneLoaded()
        {
            var sceneToLoad = Scenes.GameplaySceneName;
            _applicationStateMachine.Enter<LoadLevelState, string>(sceneToLoad).Forget();
        }
    }
}
