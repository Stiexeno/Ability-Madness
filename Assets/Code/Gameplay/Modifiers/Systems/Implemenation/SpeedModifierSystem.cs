using System.Collections.Generic;
using Entitas;

namespace AbilityMadness.Code.Gameplay.Modifiers.Systems.Implemenation
{
    public class SpeedModifierSystem : IExecuteSystem
    {
        private readonly List<GameEntity> _buffer = new(32);
        private IGroup<GameEntity> _modifiers;
        private IGroup<GameEntity> _abilityProducedEntities;

        public SpeedModifierSystem(GameContext gameContext)
        {
            _modifiers = gameContext.GetGroup(GameMatcher
                .AllOf(
                    GameMatcher.Id,
                    GameMatcher.SpeedModifier,
                    GameMatcher.TargetId,
                    GameMatcher.ModifierValue));

            _abilityProducedEntities = gameContext.GetGroup(GameMatcher
                .AllOf(
                    GameMatcher.ProducerId,
                    GameMatcher.ProducedByAbility)
                .NoneOf(
                    GameMatcher.MovementSpeed));
        }

        public void Execute()
        {
            foreach (var abilityProducedEntity in _abilityProducedEntities.GetEntities(_buffer))
            foreach (var modifier in _modifiers)
            {
                if (modifier.TargetId == abilityProducedEntity.ProducerId)
                {
                    abilityProducedEntity.AddMovementSpeed(modifier.ModifierValue);
                }
            }
        }
    }
}
