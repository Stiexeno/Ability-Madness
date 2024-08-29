using AbilityMadness.Code.Gameplay.Projectile.Directional;
using AbilityMadness.Code.Gameplay.Projectile.Throwable;
using AbilityMadness.Code.Infrastructure.ECS;

namespace AbilityMadness.Code.Gameplay.Projectile
{
    public class ProjectileFeature : Feature
    {
        public ProjectileFeature(ISystemFactory systemFactory)
        {
            Add(systemFactory.Create<DirectionalFeature>());
            Add(systemFactory.Create<ThrowableFeature>());
        }
    }
}
