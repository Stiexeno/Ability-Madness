namespace AbilityMadness.Code.Gameplay.EffectApplication.Factory
{
    public interface IEffectFactory
    {
        GameEntity CreateEffect(EffectSetup setup, int producerId, int targetId);
        GameEntity CreateEffectReceived(EffectTypeId type, int producerId, int targetId, float value);
        GameEntity CreateEffectDealt(EffectTypeId type, int producerId, int targetId, float value);
    }
}
