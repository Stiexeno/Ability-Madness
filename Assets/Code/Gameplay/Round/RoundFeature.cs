using AbilityMadness.Code.Gameplay.Round.Systems;
using AbilityMadness.Code.Infrastructure.ECS;

namespace AbilityMadness.Code.Gameplay.Round
{
    public class RoundFeature : Feature
    {
        public RoundFeature(ISystemFactory systemFactory)
        {
            Add(systemFactory.Create<RefreshRoundTimerUISystem>());
        }
    }
}
