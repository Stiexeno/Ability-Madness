using UnityEngine;

namespace AbilityMadness.Code.Gameplay.Experience.Services
{
    public class ExperienceCalculatorService : IExperienceCalculatorService
    {
        private const int baseExperience = 100;
        private const float experienceMultiplier = 1.5f;

        public int CalculateMaxExperience(int level)
        {
            int totalXP = 0;

            for (int i = 1; i <= level; i++)
            {
                totalXP += Mathf.FloorToInt(baseExperience * Mathf.Pow(level, experienceMultiplier));
            }

            return totalXP;
        }
    }
}
