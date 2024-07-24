using AbilityMadness.Infrastructure.Services.Assets;
using Cysharp.Threading.Tasks;
using UnityEngine;
using UnityEngine.SceneManagement;
using Zenject;

namespace AbilityMadness.Infrastructure.Services.StateMachine.Implementations
{
	public class BootstrapState : IState, IEnter
	{
		private string _currentScene;
		private IApplicationStateMachine _applicationStateMachine;
		private ISceneService _sceneService;
		private IAssets _assets;
		private const int TARGET_FRAME_RATE = 120;

		[Inject]
		private void Construct(
			IApplicationStateMachine applicationStateMachine,
			ISceneService sceneService,
			IAssets assets)
		{
			_assets = assets;
			_sceneService = sceneService;
			_applicationStateMachine = applicationStateMachine;
		}

		public void Enter()
		{
			SetTargetFrameRate();

			_currentScene = SceneManager.GetActiveScene().name;

			_assets.Initialize();
			_sceneService.Load(Constants.Scenes.BootSceneName, EnterLoadedScene);
		}

		private static void SetTargetFrameRate()
		{
			Application.targetFrameRate = TARGET_FRAME_RATE;
		}

		private void EnterLoadedScene()
		{
			var sceneToLoad = Constants.Scenes.GameplaySceneName;

			if (Application.isEditor && _currentScene != Constants.Scenes.BootSceneName)
			{
				_applicationStateMachine.Enter<LoadLevelState, string>(_currentScene).Forget();
			}
			else
			{
				_applicationStateMachine.Enter<LoadLevelState, string>(sceneToLoad).Forget();
			}
		}
	}
}
