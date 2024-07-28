using AbilityMadness.Code.Common;
using AbilityMadness.Code.Infrastructure.Services.Identifiers;

namespace AbilityMadness.Code.Gameplay.Chest.Factory
{
    public class ChestFactory : IChestFactory
    {
        private IIdentifierService _identifierService;

        public ChestFactory(IIdentifierService identifierService)
        {
            _identifierService = identifierService;
        }

        public GameEntity Create()
        {
            return CreateEntity.Empty()
                .AddId(_identifierService.Next());
        }
    }
}
