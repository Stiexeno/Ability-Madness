using AbilityMadness.Code.Gameplay.Upgrades.UI.Inventory;
using AbilityMadness.Code.Gameplay.Weapons.Bullets.Configs;
using Cysharp.Threading.Tasks;

namespace AbilityMadness.Code.Gameplay.Upgrades.UI.ItemSelection
{
    public interface IUpgradeSelectModel
    {
        UniTaskVoid Select(BulletSelectWidget bulletSelectWidget, BulletConfig bulletConfig);
        bool IsAnySelected();
        BulletSelectWidget GetSelectedWidget();
        void Deselect();
        void Replace(BulletWidget bulletWidget);
    }
}
