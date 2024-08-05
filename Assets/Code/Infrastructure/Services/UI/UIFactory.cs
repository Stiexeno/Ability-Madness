using System.Linq;
using AbilityMadness.Code.Common;
using AbilityMadness.Code.Extensions;
using AbilityMadness.Code.Gameplay.UI.Modifier;
using AbilityMadness.Code.Gameplay.UI.Upgrade;
using AbilityMadness.Code.Infrastructure.Services.Camera;
using AbilityMadness.Code.Infrastructure.Services.UI;
using AbilityMadness.Code.Infrastructure.Services.UI.Widgets;
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
        private Transform _worldUiRootParent;

        private IAssets _assets;
        private CameraProvider _cameraProvider;
        private IUIPool _uiPool;
        private GameContext _gameContext;

        public UIFactory(IAssets assets, CameraProvider cameraProvider, IUIPool uiPool, GameContext gameContext)
        {
            _gameContext = gameContext;
            _uiPool = uiPool;
            _cameraProvider = cameraProvider;
            _assets = assets;
            Load().Forget();
            Warmup();
        }

        private void Warmup()
        {
            _assets.LoadAsync<GameObject>(Constants.Prefabs.Widgets.DamageTextWidget).Forget();
            _assets.LoadAsync<GameObject>(Constants.Prefabs.Widgets.HealthbarWidget).Forget();
        }

        public async UniTask<DamageTextWidget> CreateDamageText(Vector3 position, int damage)
        {
            var damageText = await _uiPool.Take<DamageTextWidget>(Constants.Prefabs.Widgets.DamageTextWidget, _worldUiRootParent);
            damageText.transform.position = position;
            damageText.gameObject.SetActive(true);
            damageText.Show(damage);

            return damageText;
        }

        public GameEntity CreateHealthbar(GameEntity gameEntity)
        {
            return CreateEntity.Empty()
                .AddViewPath(Constants.Prefabs.Widgets.HealthbarWidget)
                .AddTargetId(gameEntity.Id)
                .AddWorldPosition(Vector2.one * 999)
                .With(x => x.isTransformMovement = true);
        }

        public async UniTask<GridWidget> CreateGridWidget(Transform parent)
        {
            return await _uiPool.Take<GridWidget>(Constants.Prefabs.Widgets.GridWidget, parent);
        }

        public async UniTask<UpgradeWidget> CreateUpgradeWidget(Transform parent)
        {
            return await _uiPool.Take<UpgradeWidget>(Constants.Prefabs.Widgets.UpgradeWidget, parent);
        }

        #region Factory

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
            var _worlduiRoot = await _assets.LoadAsync<GameObject>(Constants.Prefabs.WorldUIRootPath);

            _uiRootParent = _assets.Instantiate(_uiRoot, Vector3.zero, Vector3.zero).transform;
            _worldUiRootParent = _assets.Instantiate(_worlduiRoot, Vector3.zero, Vector3.zero).transform;

            var worldCanvas = _worldUiRootParent.GetComponent<Canvas>();
            worldCanvas.worldCamera = _cameraProvider.Camera;
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

        #endregion
    }
}
