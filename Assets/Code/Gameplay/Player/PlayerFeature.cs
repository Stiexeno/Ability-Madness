using AbilityMadness.Code.Gameplay.Player.Systems;
using AbilityMadness.Code.Infrastructure.Services.ECS;

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
