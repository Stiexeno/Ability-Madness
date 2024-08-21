using AbilityMadness.Code.Gameplay.DamageApplication;
using AbilityMadness.Code.Gameplay.Upgrades.UI.Inventory;
using AbilityMadness.Code.Gameplay.Upgrades.UI.ItemSelection;
using AbilityMadness.Code.Infrastructure.Services.UI.Widgets;
using Cysharp.Threading.Tasks;
using UnityEngine;

namespace AbilityMadness.Infrastructure.UI
{
	public interface IUIFactory
	{
		T CreateWindow<T>() where T : Window;
		UniTask CreateUIRoot();
        UniTask<DamageTextWidget> CreateDamageText(Vector3 position, DamageTypeId entityDamageTypeId, int damage);
        UniTask<SmallBulletWidget> CreateSmallBulletWidget(Transform parent);
        UniTask Load();
        UniTask<BulletWidget> CreateBulletWidget(Transform parent);
        UniTask<BulletSelectWidget> CreateBulletSelectWidget(Transform parent);
        UniTask<BulletDragWidget> CreateBulletDragWidget(Transform parent);
    }
}
