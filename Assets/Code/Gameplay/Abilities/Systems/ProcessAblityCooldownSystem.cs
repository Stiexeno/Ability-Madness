using System.Collections.Generic;
using Entitas;

namespace AbilityMadness.Code.Gameplay.Abilities.Systems
{
    public class ProcessAblityCooldownSystem : IExecuteSystem
    {
        private readonly List<GameEntity> _buffer = new(32);
        private IGroup<GameEntity> _abilities;

        public ProcessAblityCooldownSystem(Contexts contexts)
        {
            _abilities = contexts.game.GetGroup(GameMatcher
                .AllOf(
                    GameMatcher.Ability,
                    GameMatcher.CooldownUp)
                .NoneOf(GameMatcher.ManualLaunch));
        }

        public void Execute()
        {
            foreach (var ability in _abilities.GetEntities(_buffer))
            {
                ability.isReady = true;
            }
        }
    }
}
