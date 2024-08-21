using AbilityMadness.Code.Infrastructure.Identifiers;
using AbilityMadness.Code.Infrastructure.View;
using Zenject;

namespace AbilityMadness.Code.Common.Behaviours
{
    public class SelfInitializedView : EntityComponent
    {
        private IIdentifierService _identifierService;

        [Inject]
        private void Construct(IIdentifierService identifierService)
        {
            _identifierService = identifierService;
        }

        private void Awake()
        {
            var entity = CreateEntity.Empty()
                .AddId(_identifierService.Next())
                .AddWorldPosition(transform.position);

            EntityView.LinkEntity(entity);
        }
    }
}
