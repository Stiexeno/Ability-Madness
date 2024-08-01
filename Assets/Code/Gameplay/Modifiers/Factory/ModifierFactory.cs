using System;
using AbilityMadness.Code.Common;
using AbilityMadness.Code.Extensions;
using AbilityMadness.Code.Infrastructure.Services.Identifiers;

namespace AbilityMadness.Code.Gameplay.Modifiers.Factory
{
    public class ModifierFactory : IModifierFactory
    {
        private IIdentifierService _identifierService;

        public ModifierFactory(IIdentifierService identifierService)
        {
            _identifierService = identifierService;
        }

        public GameEntity CreateModifier(ModifierTypeId type, int targetId)
        {
            switch (type)
            {
                case ModifierTypeId.Unknown:
                    throw new Exception($"Modifier not set for {targetId} ID");
                case ModifierTypeId.ForwardMovement:
                    return CreateForwardMovementModifier(targetId);
                default:
                    throw new Exception($"ModifierTypeId {type} not supported");
            }
        }

        public GameEntity CreateForwardMovementModifier(int targetId)
        {
            return CreateEntity.Empty()
                .AddId(_identifierService.Next())
                .With(x => x.isModifier = true)
                .With(x => x.isForwardMovementModifier = true)
                .AddModifierTypeId(ModifierTypeId.ForwardMovement)
                .AddTargetId(targetId);
        }
    }
}
