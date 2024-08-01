namespace AbilityMadness.Code.Common.Cooldown
{
    public static class CooldownExtensions
    {
        public static GameEntity SetOnCooldown(this GameEntity entity)
        {
            return entity
                .AddCooldownLeft(0f);
        }
    }
}
