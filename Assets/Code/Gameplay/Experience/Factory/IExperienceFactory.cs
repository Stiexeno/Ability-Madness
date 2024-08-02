using UnityEngine;

namespace AbilityMadness.Code.Gameplay.Experience.Factory
{
    public interface IExperienceFactory
    {
        GameEntity CreateExperience(ExperienceTypeId type, Vector3 position);
    }
}
