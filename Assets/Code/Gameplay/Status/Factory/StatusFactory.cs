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

        public GameEntity CreateFireStatus(StatusScheme scheme)
        {
            return CreateEmptyStatus(scheme)
                .With(x => x.isFire = true);
        }

        private GameEntity CreateEmptyStatus(StatusScheme scheme)
        {
            return CreateEntity.Empty()
                .AddId(_identifierService.Next())
                .With(x => x.isStatus = true)

                .AddDuration(scheme.duration)
                .AddTimeLeft(scheme.duration);
        }
    }
}
