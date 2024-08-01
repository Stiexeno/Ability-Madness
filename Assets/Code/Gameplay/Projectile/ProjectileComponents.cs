using Entitas;

namespace AbilityMadness.Code.Gameplay.Projectile
{
    [Game] public class Projectile : IComponent { }

    [Game] public class ProjectileTypeComponent : IComponent { public ProjectileType Value; }
}
