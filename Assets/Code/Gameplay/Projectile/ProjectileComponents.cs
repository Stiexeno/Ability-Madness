using AbilityMadness.Code.Gameplay.Projectile.Factory;
using Entitas;

namespace AbilityMadness.Code.Gameplay.Projectile
{
    [Game] public class Projectile : IComponent { }

    [Game] public class ProjectileTypeIdComponent : IComponent { public ProjectileTypeId Value; }

    [Game] public class ProjectileRequest : IComponent { public ProjectileScheme Value; }
}
