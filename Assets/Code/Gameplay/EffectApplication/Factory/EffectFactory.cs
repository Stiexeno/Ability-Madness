using System;
using AbilityMadness.Code.Common;
using AbilityMadness.Code.Extensions;
using AbilityMadness.Code.Gameplay.DamageApplication;
using AbilityMadness.Code.Infrastructure.Services.Identifiers;

namespace AbilityMadness.Code.Gameplay.EffectApplication.Factory
{
    public class EffectFactory : IEffectFactory
    {
        private IIdentifierService _identifierService;

        public EffectFactory(IIdentifierService identifierService)
        {
            _identifierService = identifierService;
        }

        public GameEntity CreateEffect(EffectSetup setup, int producerId, int targetId)
        {
            switch (setup.type)
            {
                case EffectTypeId.Damage:
                    return CreateEmptyEffect(setup, producerId, targetId);
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }

        public GameEntity CreateEffectReceived(EffectTypeId type, DamageTypeId damageTypeId, int producerId, int targetId, float value)
        {
            return CreateEntity.Empty()
                .AddId(_identifierService.Next())
                .AddEffectReceived(targetId)

                .With(x => x.isDamageEffect = true, when: type == EffectTypeId.Damage)
                .AddEffectValue(value)

                .AddProducerId(producerId)
                .AddTargetId(targetId)
                .AddDamageTypeId(damageTypeId);
        }

        public GameEntity CreateEffectDealt(EffectTypeId type, DamageTypeId damageTypeId, int producerId, int targetId, float value)
        {
            return CreateEntity.Empty()
                .AddId(_identifierService.Next())
                .AddEffectDealt(producerId)

                .With(x => x.isDamageEffect = true, when: type == EffectTypeId.Damage)
                .AddEffectValue(value)

                .AddProducerId(producerId)
                .AddTargetId(targetId)
                .AddDamageTypeId(damageTypeId);
        }

        private GameEntity CreateEmptyEffect(EffectSetup setup, int producerId, int targetId)
        {
            return CreateEntity.Empty()
                .AddId(_identifierService.Next())
                .With(x => x.isEffectApplication = true)

                .With(x => x.isDamageEffect = true, when: setup.type == EffectTypeId.Damage)

                .AddEffectTypeId(setup.type)
                .AddProducerId(producerId)
                .AddTargetId(targetId)
                .AddEffectValue(setup.value)

                .AddDamageTypeId(setup.damageType);
        }
    }
}
