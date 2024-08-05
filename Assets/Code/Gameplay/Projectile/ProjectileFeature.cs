using AbilityMadness.Code.Gameplay.Projectile.Systems;
using AbilityMadness.Code.Infrastructure.Services.ECS;

namespace AbilityMadness.Code.Gameplay.Projectile
{
    public class ProjectileFeature : Feature
    {
        public ProjectileFeature(ISystemFactory systemFactory)
        {
            Add(systemFactory.Create<CreateProjectileByRequestSystem>());
            Add(systemFactory.Create<FaceProjectileToDirectionSystem>());
        }
    }
}
