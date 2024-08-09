
namespace AbilityMadness.Code.Gameplay.Experience.Services
{
    public class ExperienceCalculatorService : IExperienceCalculatorService
    {
        private const int baseExperience = 100;
        private const float experienceMultiplier = 1.5f;

        public int CalculateMaxExperience(int level)
        {
            return CalculateRequiredXP(level);
        }

        private int CalculateRequiredXP(int level)
        {
            if (level >= 1 && level <= 19)
            {
                return 10 * level - 5;
            }

            if (level == 20)
            {
                return 16 * level - 8;
            }

            if (level >= 21 && level <= 39)
            {
                return 13 * level - 6;
            }

            if (level >= 40 && level <= 59)
            {
                return 16 * level - 8;
            }

            if (level >= 60)
            {
                return level * level;
            }

            return 0; // In case of an invalid level input
        }
    }
}
