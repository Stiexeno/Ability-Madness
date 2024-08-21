using AbilityMadness.Code.Infrastructure.Assets;
using Cysharp.Threading.Tasks;
using UnityEngine;
using UnityEngine.SceneManagement;
using Zenject;

namespace AbilityMadness.Infrastructure.Services.StateMachine.Implementations
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
			_sceneService.Load(Constants.Scenes.BootSceneName, EnterLoadedScene);
		}

		private static void SetTargetFrameRate()
		{
			Application.targetFrameRate = TARGET_FRAME_RATE;
		}

		private void EnterLoadedScene()
		{
            _loadingCurtain.Show();
            var currentActiveScene = SceneManager.GetActiveScene().name;

            if (currentActiveScene != Constants.Scenes.GameplaySceneName)
            {
                _sceneService.Load(Constants.Scenes.GameplaySceneName, onLoaded: OnSceneLoaded);
            }
            else
            {
                OnSceneLoaded();
            }
		}

        private void OnSceneLoaded()
        {
            var sceneToLoad = Constants.Scenes.GameplaySceneName;
            _applicationStateMachine.Enter<LoadLevelState, string>(sceneToLoad).Forget();
        }
    }
}
