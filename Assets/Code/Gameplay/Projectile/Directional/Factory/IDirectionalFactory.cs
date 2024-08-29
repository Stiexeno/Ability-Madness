namespace AbilityMadness.Code.Gameplay.Projectile.Factory
{
    public interface IDirectionalFactory
    {
        GameEntity CreateDirectional(DirectionalRequest request);
    }
}
