namespace AbilityMadness.Code.Gameplay.EffectApplication
{
    public static class EffectExtensions
    {
        public static GameEntity GetEffectReceivedTarget(this GameEntity entity)
        {
            return Contexts.sharedInstance.game.GetEntityWithId(entity.EffectReceived);
        }
    }
}
