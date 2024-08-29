namespace AbilityMadness.Code.Gameplay.Projectile.Factory
{
    public interface IThrowableFactory
    {
        GameEntity CreateThrowable(ThrowableRequest request);
    }
}
