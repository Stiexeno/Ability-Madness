namespace AbilityMadness.Code.Common.Cooldown
{
    public static class CooldownExtensions
    {
        public static GameEntity SetOnCooldown(this GameEntity entity, float cooldown)
        {
            return entity
                .ReplaceCooldown(cooldown)
                .AddCooldownLeft(0f);
        }
    }
}
