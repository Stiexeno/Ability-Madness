namespace AbilityMadness.Code.Gameplay.Modifiers.Factory
{
    public interface IModifierFactory
    {
        GameEntity CreateForwardMovementModifier(int targetId);
        GameEntity CreateModifier(ModifierTypeId type, int targetId);
    }
}
