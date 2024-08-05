﻿using System.Collections.Generic;
using AbilityMadness.Code.Gameplay.Movement;
using Entitas;

namespace AbilityMadness.Code.Gameplay.Modifiers.Systems.Implemenation
{
    public class ZigZagMovementModifierSystem : IExecuteSystem
    {
        private readonly List<GameEntity> _buffer = new(32);
        private IGroup<GameEntity> _modifiers;
        private IGroup<GameEntity> _abilityProducedEntities;

        public ZigZagMovementModifierSystem(GameContext gameContext)
        {
            _modifiers = gameContext.GetGroup(GameMatcher
                .AllOf(
                    GameMatcher.Id,
                    GameMatcher.ZigZagMovementModifier,
                    GameMatcher.TargetId,
                    GameMatcher.ModifierValue));

            _abilityProducedEntities = gameContext.GetGroup(GameMatcher
                .AllOf(
                    GameMatcher.ProducerId,
                    GameMatcher.ProducedByAbility)
                .NoneOf(
                    GameMatcher.ZigZagMovement));
        }

        public void Execute()
        {
            foreach (var modifier in _modifiers)
            foreach (var abilityProducedEntity in _abilityProducedEntities.GetEntities(_buffer))
            {
                if (modifier.TargetId == abilityProducedEntity.ProducerId)
                {
                    abilityProducedEntity.SetZigZagMovement(abilityProducedEntity.Direction);
                }
            }
        }
    }
}
