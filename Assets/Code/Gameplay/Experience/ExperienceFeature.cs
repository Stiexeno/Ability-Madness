using AbilityMadness.Code.Gameplay.Experience.Systems;
using AbilityMadness.Code.Infrastructure.Services.ECS;

namespace AbilityMadness.Code.Gameplay.Experience
{
    public class ExperienceFeature : Feature
    {
        public ExperienceFeature(ISystemFactory systemFactory)
        {
            Add(systemFactory.Create<DisplayExperienceUISystem>());
            Add(systemFactory.Create<DropExperienceOnDeathSystem>());
            Add(systemFactory.Create<PlayerPickupExperienceSystem>());
            Add(systemFactory.Create<FlyExperienceToPlayerSystem>());
        }
    }
}
