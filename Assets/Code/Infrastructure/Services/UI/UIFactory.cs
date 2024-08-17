using System.Linq;
using AbilityMadness.Code.Gameplay.Upgrades.UI.Inventory;
using AbilityMadness.Code.Gameplay.Upgrades.UI.ItemSelection;
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

        public UIFactory(IAssets assets, CameraProvider cameraProvider, IUIPool uiPool)
        {
            _uiPool = uiPool;
            _cameraProvider = cameraProvider;
            _assets = assets;
            Warmup();
        }

        private void Warmup()
        {
            _assets.LoadAsync<GameObject>(Constants.Prefabs.Widgets.DamageTextWidget).Forget();
            _assets.LoadAsync<GameObject>(Constants.Prefabs.Widgets.HealthbarWidget).Forget();
            _assets.LoadAsync<GameObject>(Constants.Prefabs.Widgets.BulletDragWidget).Forget();
        }

        public async UniTask<DamageTextWidget> CreateDamageText(Vector3 position, int damage)
        {
            var damageText = await _uiPool.Take<DamageTextWidget>(Constants.Prefabs.Widgets.DamageTextWidget, _worldUiRootParent);
            damageText.transform.position = position;
            damageText.gameObject.SetActive(true);
            damageText.Show(damage);

            return damageText;
        }

        public async UniTask<SmallBulletWidget> CreateSmallBulletWidget(Transform parent)
        {
            return await _uiPool.Take<SmallBulletWidget>(Constants.Prefabs.Widgets.SmallBulletWidget, parent);
        }

        public async UniTask<BulletWidget> CreateBulletWidget(Transform parent)
        {
            return await _uiPool.Take<BulletWidget>(Constants.Prefabs.Widgets.BulletWidget, parent);
        }

        public async UniTask<BulletSelectWidget> CreateBulletSelectWidget(Transform parent)
        {
            return await _uiPool.Take<BulletSelectWidget>(Constants.Prefabs.Widgets.BulletSelectionWidget, parent);
        }

        public async UniTask<BulletDragWidget> CreateBulletDragWidget(Transform parent)
        {
            return await _uiPool.Take<BulletDragWidget>(Constants.Prefabs.Widgets.BulletDragWidget, parent);
        }

        #region Factory

        public async UniTask Load()
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
            var worlduiRoot = await _assets.LoadAsync<GameObject>(Constants.Prefabs.WorldUIRootPath);

            _uiRootParent = _assets.Instantiate(_uiRoot, Vector3.zero, Vector3.zero).transform;
            _worldUiRootParent = _assets.Instantiate(worlduiRoot, Vector3.zero, Vector3.zero).transform;

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
