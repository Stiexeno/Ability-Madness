using AbilityMadness.Code.Gameplay.Gears.UI.Inventory;
using AbilityMadness.Code.Gameplay.Weapons.Bullets.Configs;
using Cysharp.Threading.Tasks;

namespace AbilityMadness.Code.Gameplay.Gears.UI.ItemSelection
{
    public interface IItemSelectModel
    {
        UniTaskVoid Select(BulletSelectWidget bulletSelectWidget, BulletConfig bulletConfig);
        bool IsAnySelected();
        BulletSelectWidget GetSelectedWidget();
        void Deselect();
        void Replace(BulletWidget bulletWidget);
    }
}
