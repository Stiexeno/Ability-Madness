namespace AbilityMadness.Code.Gameplay.Lifetime
{
    public static class LifetimeExtensions
    {
        public static GameEntity SetLifetime(this GameEntity gameEntity, float duration)
        {
            return gameEntity
                .AddLifeTime(duration)
                .AddLifeTimeTimeElapsed(0f);
        }
    }
}
