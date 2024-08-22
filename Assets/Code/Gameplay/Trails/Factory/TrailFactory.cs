using System;
using AbilityMadness.Code.Common;
using AbilityMadness.Code.Extensions;
using AbilityMadness.Code.Infrastructure.Identifiers;

namespace AbilityMadness.Code.Gameplay.Trails.Factory
{
    public class TrailFactory : ITrailFactory
    {
        private IIdentifierService _identifierService;

        public TrailFactory(IIdentifierService identifierService)
        {
            _identifierService = identifierService;
        }

        public GameEntity CreateTrail(TrailTypeId type, int producerId, int targetId)
        {
            return type switch
            {
                _ => CreateEmptyTrail(type, producerId, targetId)
            };
        }

        private GameEntity CreateEmptyTrail(TrailTypeId type, int producerId, int targetId)
        {
            return CreateEntity.Empty()
                .AddId(_identifierService.Next())
                .With(x => x.isTrail = true)
                .AddTrailTypeId(type)

                .AddProducerId(producerId)
                .AddTargetId(targetId);
        }
    }
}
