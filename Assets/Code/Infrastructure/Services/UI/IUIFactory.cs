using AbilityMadness.Code.Gameplay.UI.Modifier;
using AbilityMadness.Code.Gameplay.UI.Upgrade;
using AbilityMadness.Code.Infrastructure.Services.UI.Widgets;
using Cysharp.Threading.Tasks;
using UnityEngine;

namespace AbilityMadness.Infrastructure.Factories.UI
{
	public interface IUIFactory
	{
		T CreateWindow<T>() where T : Window;
		UniTask CreateUIRoot();
        UniTask<DamageTextWidget> CreateDamageText(Vector3 position, int damage);
        GameEntity CreateHealthbar(GameEntity gameEntity);
        UniTask<GridWidget> CreateGridWidget(Transform parent);
        UniTask<UpgradeWidget> CreateUpgradeWidget(Transform parent);
    }
}
