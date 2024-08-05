using System.Collections.Generic;
using Entitas;

namespace AbilityMadness.Code.Gameplay.Modifiers.Systems.Implemenation
{
    public class MultishotModifierSystem : IExecuteSystem
    {
        private readonly List<GameEntity> _buffer = new(32);

        private IGroup<GameEntity> _modifiers;
        private IGroup<GameEntity> _requests;

        public MultishotModifierSystem(GameContext gameContext)
        {
            _modifiers = gameContext.GetGroup(GameMatcher
                .AllOf(
                    GameMatcher.Id,
                    GameMatcher.MultishootModifier,
                    GameMatcher.TargetId,
                    GameMatcher.ModifierValue));

            _requests = gameContext.GetGroup(GameMatcher
                .AllOf(
                    GameMatcher.ProducedByAbility,
                    GameMatcher.ProducerId,
                    GameMatcher.SpawnAmount));
        }

        public void Execute()
        {
            foreach (var modifier in _modifiers)
            foreach (var request in _requests.GetEntities(_buffer))
            {
                if (modifier.TargetId == request.ProducerId)
                {
                    request.SpawnAmount += (int)modifier.ModifierValue;
                }
            }
        }
    }
}
