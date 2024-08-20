using System;
using AbilityMadness.Code.Common;
using AbilityMadness.Code.Extensions;
using AbilityMadness.Code.Infrastructure.Services.Identifiers;

namespace AbilityMadness.Code.Gameplay.Status.Factory
{
    public class StatusViewFactory : IStatusViewFactory
    {
        private IIdentifierService _identifierService;

        public StatusViewFactory(IIdentifierService identifierService)
        {
            _identifierService = identifierService;
        }

        public GameEntity CreateStatus(StatusTypeId type, int producerId, int targetId)
        {
            return type switch
            {
                StatusTypeId.Fire => CreateFireStatus(producerId, targetId),
                _ => throw new ArgumentOutOfRangeException(nameof(type), type, null)
            };
        }

        private GameEntity CreateFireStatus(int producerId, int targetId)
        {
            return CreateEntity.Empty()
                .AddId(_identifierService.Next())
                .With(x => x.isStatusView = true)
                .AddViewPath(Constants.Prefabs.Effects.FireStatus)
                .AddTargetId(targetId)
                .AddProducerId(producerId)
                .With(x => x.isFollowMovement = true)
                .With(x => x.isTransformMovement = true);
        }
    }
}
