using System.Linq;
using AbilityMadness.Infrastructure.Services.Assets;
using Cysharp.Threading.Tasks;
using UnityEngine;

namespace AbilityMadness.Infrastructure.Factories.UI
{
	public class UIFactory : IUIFactory
	{
		private Window[] _windowPrefabs;
		private GameObject _uiRoot;
		private Transform _uiRootParent;

		private IAssets _assets;

		public UIFactory(IAssets assets)
		{
			_assets = assets;
			Load().Forget();
		}

		private async UniTaskVoid Load()
		{
			await LoadWindowPrefabs();
		}

		private async UniTask LoadWindowPrefabs()
		{
			var windowGameObjects = await _assets.GetAssetsByLabelAsync<GameObject>(Constants.Prefabs.WindowLabel);
			_windowPrefabs = windowGameObjects.Select(x => x.GetComponent<Window>()).ToArray();
		}

		public async UniTask CreateUIRoot()
		{
			_uiRoot = await _assets.LoadAsync<GameObject>(Constants.Prefabs.UIRootPath);
			_uiRootParent = _assets.Instantiate(_uiRoot, Vector3.zero, Vector3.zero).transform;
		}

		public T CreateWindow<T>() where T : Window
		{
			var window = _windowPrefabs.FirstOrDefault(x => x is T);

			if (window == null)
			{
				Debug.LogError($"Window {typeof(T).Name} not found");
				return null;
			}

			Window windowInstance = _assets.Instantiate<T>(window.gameObject, Vector3.zero, _uiRootParent);
			((RectTransform)windowInstance.transform).anchoredPosition = Vector3.zero;
			windowInstance.Close();

			return (T)windowInstance;
		}
	}
}
