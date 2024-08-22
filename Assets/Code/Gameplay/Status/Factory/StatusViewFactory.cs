using AbilityMadness.Code.Common;
using AbilityMadness.Code.Extensions;
using AbilityMadness.Code.Infrastructure.Identifiers;

namespace AbilityMadness.Code.Gameplay.Status.Factory
{
    public class StatusViewFactory : IStatusViewFactory
    {
        private IIdentifierService _identifierService;

        public StatusViewFactory(IIdentifierService identifierService)
        {
            _identifierService = identifierService;
        }

        public GameEntity CreateStatusView(StatusTypeId type, int producerId, int targetId)
        {
            return type switch
            {
                StatusTypeId.Fire => CreateFireStatusView(producerId, targetId),
                StatusTypeId.Poison => CreatePoisonStatusView(producerId, targetId),
                StatusTypeId.Freeze => CreateFreezeStatusView(producerId, targetId),
                _ => CreateEmptyStatusView(producerId, targetId)
            };
        }

        private GameEntity CreateFireStatusView(int producerId, int targetId)
        {
            return CreateEmptyStatusView(producerId, targetId)
                .With(x => x.isEmitting = true)
                .AddViewPath(Prefabs.Effects.FireStatus)
                .With(x => x.isFollowMovement = true)
                .With(x => x.isTransformMovement = true);
        }

        private GameEntity CreatePoisonStatusView(int producerId, int targetId)
        {
            return CreateEmptyStatusView(producerId, targetId)
                .With(x => x.isEmitting = true)
                .AddViewPath(Prefabs.Effects.PoisonStatus)
                .With(x => x.isFollowMovement = true)
                .With(x => x.isTransformMovement = true);
        }

        private GameEntity CreateFreezeStatusView(int producerId, int targetId)
        {
            return CreateEmptyStatusView(producerId, targetId)
                .With(x => x.isEmitting = true)
                .AddViewPath(Prefabs.Effects.FreezeStatus)
                .With(x => x.isFollowMovement = true)
                .With(x => x.isTransformMovement = true);
        }

        private GameEntity CreateEmptyStatusView(int producerId, int targetId)
        {
            return CreateEntity.Empty()
                .AddId(_identifierService.Next())
                .With(x => x.isStatusView = true)
                .AddTargetId(targetId)
                .AddProducerId(producerId);
        }
    }
}
