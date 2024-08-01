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
        private static AbilityConfig _config;

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
            _config = _configsService.GetAbilityConfig(type);

            switch (type)
            {
                case AbilityTypeId.Fireball:
                    return CreateFireball(owner);
                case AbilityTypeId.Tornado:
                    return CreateTornado(owner);
                default:
                    throw new Exception($"AbilityTypeId {type} not supported");
            }
        }

        private GameEntity CreateFireball(GameEntity owner)
        {
            return CreateEmptyAbility(owner)
                .With(x => x.isFireballAbility = true)
                .With(x => x.isAutoLaunch = true)
                .AddAbilityTypeId(AbilityTypeId.Fireball)

                .AddCooldown(_config.cooldown);
        }

        private GameEntity CreateTornado(GameEntity owner)
        {
            return CreateEmptyAbility(owner)
                .With(x => x.isTornadoAbility = true)
                .With(x => x.isAutoLaunch = true)
                .AddAbilityTypeId(AbilityTypeId.Tornado)

                .AddCooldown(_config.cooldown);
        }

        private GameEntity CreateEmptyAbility(GameEntity owner)
        {
            var abilityId = _identifierService.Next();

            var abilityEntity = CreateEntity.Empty()
                .AddId(abilityId)
                .With(x => x.isAbility = true)
                .With(x => x.isReady = true)
                .AddProducerId(owner.Id)
                .AddTeam(owner.Team);

            CreateModifiersFromConfig(abilityId);
            return abilityEntity;
        }

        private void CreateModifiersFromConfig(int id)
        {
            foreach (var modifierConfig in _config.modifiers)
            {
               _modifierFactory.CreateModifier(modifierConfig.type, id, modifierConfig.value);
            }
        }
    }
}
