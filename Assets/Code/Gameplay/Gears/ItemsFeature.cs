using AbilityMadness.Code.Gameplay.Gears.Systems;
using AbilityMadness.Code.Infrastructure.Services.ECS;

namespace AbilityMadness.Code.Gameplay.Gears
{
    public class ItemsFeature : Feature
    {
        public ItemsFeature(ISystemFactory systemFactory)
        {
            Add(systemFactory.Create<OpenItemSelectionWindowSystem>());
        }
    }
}
