using System;
using AbilityMadness.Code.Common;
using AbilityMadness.Code.Extensions;
using AbilityMadness.Code.Infrastructure.Services.Identifiers;

namespace AbilityMadness.Code.Gameplay.Status.Factory
{
    public class StatusFactory : IStatusFactory
    {
        private IIdentifierService _identifierService;

        public StatusFactory(IIdentifierService identifierService)
        {
            _identifierService = identifierService;
        }

        public GameEntity CreateStatus(StatusSetup setup, int producerId, int targetId)
        {
            return setup.type switch
            {
                StatusTypeId.Fire => CreateFireStatus(setup, producerId, targetId),
                _ => throw new ArgumentOutOfRangeException()
            };
        }

        private GameEntity CreateFireStatus(StatusSetup setup, int producerId, int targetId)
        {
            return CreateEmptyStatus(setup, producerId, targetId)
                .With(x => x.isFire = true);
        }

        private GameEntity CreateEmptyStatus(StatusSetup setup, int producerId, int targetId)
        {
            return CreateEntity.Empty()
                .AddId(_identifierService.Next())
                .With(x => x.isStatus = true)
                .AddStatusTypeId(setup.type)
                .AddProducerId(producerId)
                .AddTargetId(targetId)

                .AddStatusValue(setup.value)
                .AddDuration(setup.duration)
                .AddTimeLeft(setup.duration);
        }
    }
}
