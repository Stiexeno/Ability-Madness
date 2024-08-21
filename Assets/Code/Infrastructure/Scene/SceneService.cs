using System;
using System.Collections;
using AbilityMadness.Code.Infrastructure.Coroutine;
using UnityEngine.SceneManagement;

namespace AbilityMadness.Code.Infrastructure.Scene
{
	public class SceneService : ISceneService
	{
		private UnityEngine.Coroutine _loading;

		private ICoroutineRunner _coroutineRunner;

		public SceneService(ICoroutineRunner coroutineRunner)
		{
			_coroutineRunner = coroutineRunner;
		}

		public void Load(string name, Action onLoaded = null)
		{
			if (_loading != null)
				return;

			_loading = _coroutineRunner.StartCoroutine(LoadAsync(name, onLoaded));
		}

		private IEnumerator LoadAsync(string name, Action onLoaded)
		{
			var sceneLoading = SceneManager.LoadSceneAsync(name);

			while (!sceneLoading.isDone)
				yield return null;

			_loading = null;
			onLoaded?.Invoke();
		}
	}
}
