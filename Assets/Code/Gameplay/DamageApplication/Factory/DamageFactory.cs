using AbilityMadness.Code.Common;
using AbilityMadness.Code.Extensions;
using AbilityMadness.Code.Infrastructure.Services.Identifiers;

namespace AbilityMadness.Code.Gameplay.DamageApplication.Factory
{
    public class DamageFactory : IDamageFactory
    {
        private IIdentifierService _identifierService;

        public DamageFactory(IIdentifierService identifierService)
        {
            _identifierService = identifierService;
        }

        public GameEntity CreateDamageRequest(int producerId, int targetId, int damage)
        {
            return CreateEntity.Empty()
                .AddId(_identifierService.Next())
                .With(x => x.isDamageRequest = true)

                .AddProducerId(producerId)
                .AddTargetId(targetId)
                .AddDamage(damage);
        }

        public GameEntity CreateDamageReceived(int producerId, int targetId, int damage)
        {
            return CreateEntity.Empty()
                .AddId(_identifierService.Next())
                .With(x => x.isDamageReceived = true)

                .AddProducerId(producerId)
                .AddTargetId(targetId)
                .AddDamage(damage);
        }

        public GameEntity CreateDamageDealt(int producerId, int targetId, int damage)
        {
            return CreateEntity.Empty()
                .AddId(_identifierService.Next())
                .With(x => x.isDamageDealt = true)

                .AddProducerId(producerId)
                .AddTargetId(targetId)
                .AddDamage(damage);
        }
    }
}
