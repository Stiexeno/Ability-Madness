using AbilityMadness.Code.Common;
using AbilityMadness.Code.Extensions;
using AbilityMadness.Code.Gameplay.Area;
using AbilityMadness.Code.Infrastructure.Identifiers;
using UnityEngine;

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
                TrailTypeId.Fire => CreateFireTrail(producerId, targetId),
                TrailTypeId.Poison => CreatePoisonTrail(producerId, targetId),
                TrailTypeId.Freeze => CreateFreezeTrail(producerId, targetId),
                _ => CreateEmptyTrail(type, producerId, targetId)
            };
        }

        private GameEntity CreateFireTrail(int producerId, int targetId)
        {
            return CreateEmptyTrail(TrailTypeId.Fire, producerId, targetId)
                .AddAreaTypeId(AreaTypeId.Fire);
        }

        private GameEntity CreatePoisonTrail(int producerId, int targetId)
        {
            return CreateEmptyTrail(TrailTypeId.Poison, producerId, targetId)
                .AddAreaTypeId(AreaTypeId.Poison);
        }

        private GameEntity CreateFreezeTrail(int producerId, int targetId)
        {
            return CreateEmptyTrail(TrailTypeId.Freeze, producerId, targetId)
                .AddAreaTypeId(AreaTypeId.Freeze);
        }

        private GameEntity CreateEmptyTrail(TrailTypeId type, int producerId, int targetId)
        {
            return CreateEntity.Empty()
                .AddId(_identifierService.Next())
                .With(x => x.isTrail = true)
                .AddTrailTypeId(type)

                .AddProducerId(producerId)
                .AddTargetId(targetId)
                .AddDistanceThreshold(0.7f)
                .AddDistanceTraveled(0)
                .AddLastPosition(Vector3.zero);
        }
    }
}
