using AbilityMadness.Code.Infrastructure.Services.ECS;
using AbilityMadness.Systems;

namespace AbilityMadness
{
    public class PlayerFeature : Feature
    {
        public PlayerFeature(ISystemFactory systemFactory)
        {
            Add(systemFactory.Create<SetPlayerDirectionByInputSystem>());
            Add(systemFactory.Create<SetPlayerLookDirectionByInputSystem>());

            Add(systemFactory.Create<MarkPlayerInTriggerSystem>());
            Add(systemFactory.Create<RemovePlayerInTriggerSystem>());

            Add(systemFactory.Create<PlayerAttackingSystem>());
            Add(systemFactory.Create<PlayerDashingSystem>());
        }
    }
}
