using AbilityMadness.Code.Gameplay.Chest.Systems;
using AbilityMadness.Code.Infrastructure.ECS;

namespace AbilityMadness.Code.Gameplay.Chest
{
    public class ChestFreature : Feature
    {
        public ChestFreature(ISystemFactory systemFactory)
        {
            Add(systemFactory.Create<ShowChestOutlineSystem>());
            Add(systemFactory.Create<SetChestCursorInteractSystem>());
        }
    }
}
