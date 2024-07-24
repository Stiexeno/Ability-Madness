using AbilityMadness.Code.Common;
using AbilityMadness.Code.Gameplay;

namespace AbilityMadness.Code.Infrastructure.Services.ECS
{
    public class BattleUpdateFeature : Feature
    {
        public BattleUpdateFeature(ISystemFactory systemFactory)
        {
            Add(systemFactory.Create<ViewFeature>());

            Add(systemFactory.Create<CleanupDestructedSystem>());
        }
    }
}
