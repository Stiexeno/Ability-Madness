using Entitas;

namespace AbilityMadness.Code.Gameplay.Projectile
{
    [Game] public class Projectile : IComponent { }

    [Game] public class ProjectileTypeIdComponent : IComponent { public ProjectileTypeId Value; }
}
