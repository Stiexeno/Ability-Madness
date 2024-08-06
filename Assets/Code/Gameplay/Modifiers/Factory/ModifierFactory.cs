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

        public GameEntity CreateModifier(ModifierTypeId type, int targetId, float value)
        {
            switch (type)
            {
                case ModifierTypeId.ForwardMovement:
                    return CreateForwardMovementModifier(targetId, value);
                case ModifierTypeId.Speed:
                    return CreateSpeedModifier(targetId, value);
                case ModifierTypeId.ZigZagMovement:
                    return CreateZigZagModifier(targetId, value);
                case ModifierTypeId.Multishoot:
                    return CreateMultishootModifier(targetId, value);
                case ModifierTypeId.Ricochet:
                    return CreateRicochetModifier(targetId, value);
                case ModifierTypeId.Unknown:
                    throw new Exception($"Modifier not set for {targetId} ID");
                default:
                    return default;
            }
        }

        public GameEntity CreateForwardMovementModifier(int targetId, float value)
        {
            return CreateEmptyModifier(targetId)
                .With(x => x.isForwardMovementModifier = true)
                .AddModifierTypeId(ModifierTypeId.ForwardMovement);
        }

        public GameEntity CreateZigZagModifier(int targetId, float value)
        {
            return CreateEmptyModifier(targetId)
                .With(x => x.isZigZagMovementModifier = true)
                .AddModifierTypeId(ModifierTypeId.ZigZagMovement)
                .AddModifierValue(value);
        }

        public GameEntity CreateSpeedModifier(int targetId, float value)
        {
            return CreateEmptyModifier(targetId)
                .With(x => x.isSpeedModifier = true)
                .AddModifierTypeId(ModifierTypeId.Speed)
                .AddModifierValue(value);
        }

        public GameEntity CreateMultishootModifier(int targetId, float value)
        {
            return CreateEmptyModifier(targetId)
                .With(x => x.isMultishootModifier = true)
                .AddModifierTypeId(ModifierTypeId.Multishoot)
                .AddModifierValue(value);
        }

        public GameEntity CreateRicochetModifier(int targetId, float value)
        {
            return CreateEmptyModifier(targetId)
                .With(x => x.isRicochetModifier = true)
                .AddModifierTypeId(ModifierTypeId.Ricochet)
                .AddModifierValue(value);
        }

        private GameEntity CreateEmptyModifier(int targetId)
        {
            return CreateEntity.Empty()
                .AddId(_identifierService.Next())
                .With(x => x.isModifier = true)
                .AddTargetId(targetId);
        }
    }
}
