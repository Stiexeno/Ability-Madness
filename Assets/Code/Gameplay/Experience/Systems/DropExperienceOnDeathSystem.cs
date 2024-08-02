using AbilityMadness.Code.Gameplay.Experience.Factory;
using Entitas;

namespace AbilityMadness.Code.Gameplay.Experience.Systems
{
    public class DropExperienceOnDeathSystem : IExecuteSystem
    {
        private IGroup<GameEntity> _deadEntities;
        private IExperienceFactory _experienceFactory;

        public DropExperienceOnDeathSystem(GameContext gameContext, IExperienceFactory experienceFactory)
        {
            _experienceFactory = experienceFactory;
            _deadEntities = gameContext.GetGroup(GameMatcher
                .AllOf(
                    GameMatcher.Dead,
                    GameMatcher.ExperienceTypeId,
                    GameMatcher.WorldPosition,
                    GameMatcher.Destructed));
        }

        public void Execute()
        {
            foreach (var deadEntity in _deadEntities)
            {
                _experienceFactory.CreateExperience(deadEntity.ExperienceTypeId, deadEntity.WorldPosition);
            }
        }
    }
}
