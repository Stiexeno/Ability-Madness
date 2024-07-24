using AbilityMadness.Code.Infrastructure.Services.ECS;
using AbilityMadness.Infrastructure.Factories.UI;
using Cysharp.Threading.Tasks;
using UnityEngine.SceneManagement;
using Zenject;

namespace AbilityMadness.Infrastructure.Services.StateMachine.Implementations
{
	public class LoadLevelState : IState, IPayloadedEnter<string>
	{
		private ISceneService _sceneService;
		private IUIFactory _uiFactory;
        private IECSFacade _ecsFacade;
        private IApplicationStateMachine _applicationStateMachine;

        [Inject]
		private void Construct(
			ISceneService sceneService,
			IUIFactory uiFactory,
			IUIService iuiService,
			IApplicationStateMachine applicationStateMachine,
            IECSFacade ecsFacade)
		{
            _applicationStateMachine = applicationStateMachine;
            _ecsFacade = ecsFacade;
            _uiFactory = uiFactory;
			_sceneService = sceneService;
		}

		public void Enter(string sceneName)
		{
            _ecsFacade.CleanUp();

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
			SetupUI().Forget();
            _applicationStateMachine.Enter<GameLoopState>();
		}

		private async UniTaskVoid SetupUI()
		{
			await _uiFactory.CreateUIRoot();
			SetupWindows();
		}

		private void SetupWindows()
		{
			//_iuiService.Open<MenuWindow>();
		}
	}
}
