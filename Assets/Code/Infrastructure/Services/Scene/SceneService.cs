using System;
using System.Collections;
using AbilityMadness.Infrastructure.Services;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace AbilityMadness
{
	public class SceneService : ISceneService
	{
		private Coroutine _loading;

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
