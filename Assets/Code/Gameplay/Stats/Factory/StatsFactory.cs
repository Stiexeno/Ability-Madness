using AbilityMadness.Code.Common;
using AbilityMadness.Code.Infrastructure.Identifiers;

namespace AbilityMadness.Code.Gameplay.Stats.Factory
{
    public class StatsFactory : IStatsFactory
    {
        private IIdentifierService _identifierService;

        public StatsFactory(IIdentifierService identifierService)
        {
            _identifierService = identifierService;
        }

        public GameEntity CreateStatsChange(StatsTypeId type, int producerId, int targetId, float value)
        {
            return CreateEntity.Empty()
                .AddId(_identifierService.Next())
                .AddStatsChange(type)
                .AddProducerId(producerId)
                .AddTargetId(targetId)
                .AddStatsValue(value);
        }
    }
}
