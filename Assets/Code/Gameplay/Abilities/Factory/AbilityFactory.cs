using System;
using AbilityMadness.Code.Common;
using AbilityMadness.Code.Extensions;
using AbilityMadness.Code.Gameplay.Abilities.Configs;
using AbilityMadness.Code.Gameplay.Modifiers.Factory;
using AbilityMadness.Code.Infrastructure.Services.Identifiers;
using AbilityMadness.Infrastructure.Services.Configs;

namespace AbilityMadness.Code.Gameplay.Abilities.Factory
{
    public class AbilityFactory : IAbilityFactory
    {
        private IIdentifierService _identifierService;
        private IModifierFactory _modifierFactory;
        private IConfigsService _configsService;

        public AbilityFactory(
            IIdentifierService identifierService,
            IModifierFactory modifierFactory,
            IConfigsService configsService)
        {
            _configsService = configsService;
            _modifierFactory = modifierFactory;
            _identifierService = identifierService;
        }

        public GameEntity CreateAbility(GameEntity owner, AbilityTypeId type)
        {
            var config = _configsService.GetAbilityConfig(type);

            switch (type)
            {
                case AbilityTypeId.Fireball:
                    return CreateFireball(owner, config);
                case AbilityTypeId.Arrow:
                    return CreateArrow(owner, config);
                default:
                    throw new Exception($"AbilityTypeId {type} not supported");
            }
        }

        public GameEntity CreateFireball(GameEntity owner, AbilityConfig abilityConfig)
        {
            return CreateEmptyAbility(owner, abilityConfig)
                .With(x => x.isFireballAbility = true)
                .With(x => x.isAutoLaunch = true)
                .AddAbilityTypeId(AbilityTypeId.Fireball)

                .AddCooldown(abilityConfig.cooldown);
        }

        public GameEntity CreateArrow(GameEntity owner, AbilityConfig abilityConfig)
        {
            return CreateEmptyAbility(owner, abilityConfig)
                .With(x => x.isArrowAbility = true)
                .AddAbilityTypeId(AbilityTypeId.Arrow)
                .With(x => x.isAutoLaunch = true)

                .AddCooldown(abilityConfig.cooldown);
        }

        private GameEntity CreateEmptyAbility(GameEntity owner, AbilityConfig abilityConfig)
        {
            var abilityId = _identifierService.Next();

            var abilityEntity = CreateEntity.Empty()
                .AddId(abilityId)
                .With(x => x.isAbility = true)
                .AddProducerId(owner.Id)
                .AddTeam(owner.Team)
                .With(x => x.isReady = true);

            CreateModifiersFromConfig(abilityId, abilityConfig);
            return abilityEntity;
        }

        private void CreateModifiersFromConfig(int id, AbilityConfig abilityConfig)
        {
            foreach (var modifierConfig in abilityConfig.modifiers)
            {
               _modifierFactory.CreateModifier(modifierConfig.type, id);
            }
        }
    }
}
