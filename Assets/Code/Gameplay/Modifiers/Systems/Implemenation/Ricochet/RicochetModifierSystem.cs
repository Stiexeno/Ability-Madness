using System.Collections.Generic;
using Entitas;
using UnityEngine;

namespace AbilityMadness.Code.Gameplay.Modifiers.Systems.Implemenation.Ricochet
{
    public class RicochetModifierSystem : IExecuteSystem
    {
        private readonly List<GameEntity> _buffer = new(32);
        private IGroup<GameEntity> _modifiers;
        private IGroup<GameEntity> _producedEntities;

        public RicochetModifierSystem(GameContext gameContext)
        {
            _modifiers = gameContext.GetGroup(GameMatcher
                .AllOf(
                    GameMatcher.Id,
                    GameMatcher.RicochetModifier,
                    GameMatcher.TargetId,
                    GameMatcher.ModifierValue));

            _producedEntities = gameContext.GetGroup(GameMatcher
                .AllOf(
                    GameMatcher.ProducerId,
                    GameMatcher.ProducedByAbility)
                .NoneOf(
                    GameMatcher.Ricochet,
                    GameMatcher.RicochetHitCount));
        }

        public void Execute()
        {
            foreach (var modifier in _modifiers)
            foreach (var entity in _producedEntities.GetEntities(_buffer))
            {
                if ( modifier.TargetId == entity.ProducerId)
                {
                    entity.isRicochet = true;
                    entity.AddRicochetHitCount(Mathf.RoundToInt(modifier.ModifierValue));
                }
            }
        }
    }
}
