using AbilityMadness.Code.Gameplay.Experience.Systems;
using AbilityMadness.Code.Gameplay.Player.Systems;
using AbilityMadness.Code.Infrastructure.ECS;

namespace AbilityMadness.Code.Gameplay.Experience
{
    public class ExperienceFeature : Feature
    {
        public ExperienceFeature(ISystemFactory systemFactory)
        {
            Add(systemFactory.Create<RefreshExperienceUISystem>());
            Add(systemFactory.Create<DropExperienceOnDeathSystem>());
            Add(systemFactory.Create<PlayerPickupExperienceSystem>());
            Add(systemFactory.Create<FlyExperienceToPlayerSystem>());

            Add(systemFactory.Create<LevelUpSystem>());

            Add(systemFactory.Create<CleanupLevelUpSystem>());
        }
    }
}
