using AbilityMadness.Code.Gameplay.Projectile.Systems;
using AbilityMadness.Code.Infrastructure.ECS;

namespace AbilityMadness.Code.Gameplay.Projectile.Directional
{
    public class DirectionalFeature : Feature
    {
        public DirectionalFeature(ISystemFactory systemFactory)
        {
            Add(systemFactory.Create<FaceProjectileToDirectionSystem>());

            Add(systemFactory.Create<SlowdownProjectileSystem>());

            Add(systemFactory.Create<IncreaseProjectilePierceOnDamageDealtSystem>());
            Add(systemFactory.Create<DestructProjectileOnPierceSystem>());
        }
    }
}
