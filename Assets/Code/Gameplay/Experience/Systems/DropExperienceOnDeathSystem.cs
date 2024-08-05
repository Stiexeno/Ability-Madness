using System.Collections.Generic;
using AbilityMadness.Code.Gameplay.Experience.Factory;
using Entitas;

namespace AbilityMadness.Code.Gameplay.Experience.Systems
{
    public class DropExperienceOnDeathSystem : IExecuteSystem
    {
        private readonly List<GameEntity> _buffer = new(32);

        private IGroup<GameEntity> _deadEntities;
        private IExperienceFactory _experienceFactory;

        public DropExperienceOnDeathSystem(GameContext gameContext, IExperienceFactory experienceFactory)
        {
            _experienceFactory = experienceFactory;
            _deadEntities = gameContext.GetGroup(GameMatcher
                .AllOf(
                    GameMatcher.Dead,
                    GameMatcher.ExperienceTypeId,
                    GameMatcher.WorldPosition));
        }

        public void Execute()
        {
            foreach (var deadEntity in _deadEntities.GetEntities(_buffer))
            {
                _experienceFactory.CreateExperience(deadEntity.ExperienceTypeId, deadEntity.WorldPosition);
                deadEntity.RemoveExperienceTypeId();
            }
        }
    }
}
