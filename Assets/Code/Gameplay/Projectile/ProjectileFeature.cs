using AbilityMadness.Code.Gameplay.Projectile.Systems;
using AbilityMadness.Code.Infrastructure.ECS;

namespace AbilityMadness.Code.Gameplay.Projectile
{
    public class ProjectileFeature : Feature
    {
        public ProjectileFeature(ISystemFactory systemFactory)
        {
            Add(systemFactory.Create<FaceProjectileToDirectionSystem>());

            Add(systemFactory.Create<SlowdownProjectileSystem>());

            Add(systemFactory.Create<IncreaseProjectilePierceOnDamageDealtSystem>());
            Add(systemFactory.Create<DestructProjectileOnPierceSystem>());
        }
    }
}
