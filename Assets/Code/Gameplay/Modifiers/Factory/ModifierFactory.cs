using System;
using AbilityMadness.Code.Common;
using AbilityMadness.Code.Extensions;
using AbilityMadness.Code.Infrastructure.Services.Identifiers;

namespace AbilityMadness.Code.Gameplay.Modifiers.Factory
{
    public class ModifierFactory : IModifierFactory
    {
        public GameEntity CreateModifier(GameEntity gameEntity, ModifierTypeId type, float value)
        {
            return type switch
            {
                ModifierTypeId.Speed => CreateSpeedModifier(gameEntity, value),
                ModifierTypeId.Ricochet => CreateRicochetModifier(gameEntity, value),
                ModifierTypeId.LifeSteal => CreateLifeStealModifier(gameEntity, value),

                ModifierTypeId.Unknown => throw new Exception($"Modifier not set for {gameEntity} ID"),
                _ => default
            };
        }

        private GameEntity CreateSpeedModifier(GameEntity gameEntity, float value)
        {
            return gameEntity
                .ReplaceMovementSpeed(gameEntity.MovementSpeed + value);
        }

        private GameEntity CreateRicochetModifier(GameEntity gameEntity, float value)
        {
            return gameEntity
                .With(x => x.isRicochet = true)
                .AddRicochetHitCount((int)value);
        }

        private GameEntity CreateLifeStealModifier(GameEntity gameEntity, float value)
        {
            return gameEntity
                .AddLifeSteal((int)value);
        }
    }
}
