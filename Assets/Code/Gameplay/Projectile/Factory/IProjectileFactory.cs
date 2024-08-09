namespace AbilityMadness.Code.Gameplay.Projectile.Factory
{
    public interface IProjectileFactory
    {
        GameEntity CreateProjectile(ProjectileScheme scheme);
        GameEntity CreateProjectileRequest(ProjectileScheme scheme);
    }
}
