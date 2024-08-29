using AbilityMadness.Code.Gameplay.Projectile.Systems.Implementations;
using AbilityMadness.Code.Gameplay.Projectile.Systems.Implementations.View;
using AbilityMadness.Code.Infrastructure.ECS;

namespace AbilityMadness.Code.Gameplay.Projectile.Throwable
{
    public class ThrowableFeature : Feature
    {
        public ThrowableFeature(ISystemFactory systemFactory)
        {
            Add(systemFactory.Create<MoveThrowableProjectileSystem>());
            Add(systemFactory.Create<SetHeightToThrowableAnimatorSystem>());

            Add(systemFactory.Create<CreateAreaOnThrowableDepletedSystem>());

            Add(systemFactory.Create<CleanupDepletedThrowablesSystem>());
        }
    }
}
