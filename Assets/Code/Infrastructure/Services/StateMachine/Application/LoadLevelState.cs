using AbilityMadness.Code.Infrastructure.Services.ECS;
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

        [Inject]
		private void Construct(
			ISceneService sceneService,
			IUIFactory uiFactory,
			IUIService iuiService,
			IApplicationStateMachine applicationStateMachine,
            IPlayerFactory playerFactory)
		{
            _iuiService = iuiService;
            _playerFactory = playerFactory;
            _applicationStateMachine = applicationStateMachine;
            _uiFactory = uiFactory;
			_sceneService = sceneService;
		}

		public void Enter(string sceneName)
		{
			var currentActiveScene = SceneManager.GetActiveScene().name;

			if (currentActiveScene != sceneName)
			{
				_sceneService.Load(sceneName, onLoaded: OnSceneLoaded);
			}
			else
			{
				OnSceneLoaded();
			}
		}

		private void OnSceneLoaded()
		{
            SetupScene().Forget();
		}

        private async UniTask SetupScene()
        {
            await SetupUI();
            CreatePlayer();

            _applicationStateMachine.Enter<BattleLoopState>();
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
            _playerFactory.CreatePlayer(Vector3.zero);
        }
	}
}
