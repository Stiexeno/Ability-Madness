using AbilityMadness.Code.Gameplay.Items.Systems;
using AbilityMadness.Code.Infrastructure.Services.ECS;

namespace AbilityMadness.Code.Gameplay.Items
{
    public class ItemsFeature : Feature
    {
        public ItemsFeature(ISystemFactory systemFactory)
        {
            Add(systemFactory.Create<OpenItemSelectionWindowSystem>());
        }
    }
}
