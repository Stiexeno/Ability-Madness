using AbilityMadness.Code.Gameplay.Projectile.Systems;
using AbilityMadness.Code.Infrastructure.Services.ECS;

namespace AbilityMadness.Code.Gameplay.Projectile
{
    public class ProjectileFeature : Feature
    {
        public ProjectileFeature(ISystemFactory systemFactory)
        {
            Add(systemFactory.Create<FaceProjectileToDirectionSystem>());
            Add(systemFactory.Create<CreateProjectileByRequestSystem>());
        }
    }
}
