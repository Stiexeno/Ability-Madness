using AbilityMadness.Code.Common;
using AbilityMadness.Code.Extensions;
using AbilityMadness.Code.Infrastructure.Services.Identifiers;

namespace AbilityMadness.Code.Gameplay.Abilities.Factory
{
    public class AbilityFactory : IAbilityFactory
    {
        private IIdentifierService _identifierService;

        public AbilityFactory(IIdentifierService identifierService)
        {
            _identifierService = identifierService;
        }

        public GameEntity CreateFireball(GameEntity owner)
        {
            return CreateEntity.Empty()
                .With(x => x.isAbility = true)
                .AddId(_identifierService.Next())
                .AddOwnerId(owner.Id)

                .With(x => x.isManualLaunch = true)
                .With(x => x.isRangedAttack = true);
        }
    }
}
