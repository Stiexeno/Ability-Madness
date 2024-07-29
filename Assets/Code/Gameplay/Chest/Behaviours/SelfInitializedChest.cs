using AbilityMadness.Code.Gameplay.Chest.Factory;
using AbilityMadness.Code.Infrastructure.View;
using Zenject;

namespace AbilityMadness.Code.Gameplay.Chest.Behaviours
{
    [EntityTag("Chests")]
    public class SelfInitializedChest : EntityComponent
    {
        private IChestFactory _chestFactory;

        [Inject]
        private void Construct(IChestFactory chestFactory)
        {
            _chestFactory = chestFactory;
        }

        private void Awake()
        {
            var entity = _chestFactory.Create();
            entity.AddView(EntityView);

            EntityView.LinkEntity(entity);
        }
    }
}
