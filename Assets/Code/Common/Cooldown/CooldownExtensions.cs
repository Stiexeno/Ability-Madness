namespace AbilityMadness.Code.Common.Cooldown
{
    public static class CooldownExtensions
    {
        public static GameEntity SetCooldown(this GameEntity entity, float cooldown)
        {
            return entity
                .AddCooldown(cooldown)
                .AddCooldownLeft(0f);
        }
    }
}
