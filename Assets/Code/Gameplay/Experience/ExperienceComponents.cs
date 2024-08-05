using Entitas;

namespace AbilityMadness.Code.Gameplay.Experience
{
    [Game] public class Level : IComponent { public int Value; }
    [Game] public class Experience : IComponent { public int Value; }
    [Game] public class MaxExperience : IComponent { public int Value; }

    [Game] public class PickupRadius : IComponent { public float Value; }
    [Game] public class PickedUp : IComponent { }

    [Game] public class ExperienceTypeIdComponent : IComponent { public ExperienceTypeId Value; }
}
