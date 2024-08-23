using AbilityMadness.Code.Gameplay.Upgrades.Configs;

namespace AbilityMadness.Code.Gameplay.Upgrades.Services
{
    public interface IUpgradeService
    {
        void Upgrade();
        void Load();
        void RemoveFromPool(ItemConfig item);
    }
}
