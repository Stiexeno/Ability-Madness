namespace AbilityMadness.Code.Gameplay.Projectile
{
    public interface IProjectileFactory
    {
        GameEntity CreateProjectile(ProjectileTypeId type, GameEntity weapon, GameEntity bullet, GameEntity owner, int index);
    }
}
