using AbilityMadness.Code.Gameplay.Experience.Services;
using Entitas;

namespace AbilityMadness.Code.Gameplay.Experience.Systems
{
    public class LevelUpSystem : IExecuteSystem
    {
        private IGroup<GameEntity> _entities;
        private IExperienceCalculatorService _experienceCalculator;

        public LevelUpSystem(GameContext gameContext, IExperienceCalculatorService experienceCalculator)
        {
            _experienceCalculator = experienceCalculator;
            _entities = gameContext.GetGroup(GameMatcher
                .AllOf(
                    GameMatcher.Level,
                    GameMatcher.Experience,
                    GameMatcher.MaxExperience));
        }

        public void Execute()
        {
            foreach (var entity in _entities)
            {
                if (entity.Experience >= entity.MaxExperience)
                {
                    entity.Experience = 0;
                    entity.Level++;
                    entity.MaxExperience = _experienceCalculator.CalculateMaxExperience(entity.Level);

                    entity.isLevelUp = true;
                }
            }
        }
    }
}
