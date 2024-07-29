using AbilityMadness.Code.Gameplay.Vitals.Systems;
using AbilityMadness.Code.Infrastructure.Services.ECS;

namespace AbilityMadness.Code.Gameplay.Vitals
{
    public class VitalsFeature : Feature
    {
        public VitalsFeature(ISystemFactory systemFactory)
        {
            Add(systemFactory.Create<DecreaseWaterSystem>());
            Add(systemFactory.Create<SetWaterUISystem>());

            Add(systemFactory.Create<DecreaseFoodSystem>());
            Add(systemFactory.Create<SetFoodUISystem>());

            Add(systemFactory.Create<SetHealthUISystem>());
        }
    }
}
