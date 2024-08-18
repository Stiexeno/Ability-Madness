using AbilityMadness.Code.Gameplay.Upgrades.Systems;
using AbilityMadness.Code.Infrastructure.Services.ECS;

namespace AbilityMadness.Code.Gameplay.Upgrades
{
    public class UpgradeFeature : Feature
    {
        public UpgradeFeature(ISystemFactory systemFactory)
        {
            Add(systemFactory.Create<OpenUpgradeSelectWindowSystem>());
        }
    }
}