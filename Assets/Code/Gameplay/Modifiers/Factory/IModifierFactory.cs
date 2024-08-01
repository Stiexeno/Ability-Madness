namespace AbilityMadness.Code.Gameplay.Modifiers.Factory
{
    public interface IModifierFactory
    {
        GameEntity CreateForwardMovementModifier(int targetId, float value);
        GameEntity CreateModifier(ModifierTypeId type, int targetId, float value);
        GameEntity CreateSpeedModifier(int targetId, float value);
    }
}
