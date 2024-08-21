namespace AbilityMadness.Code.Gameplay.Projectile.Factory
{
    public interface IProjectileFactory
    {
        GameEntity CreateProjectile(ProjectileRequest request);
    }
}
