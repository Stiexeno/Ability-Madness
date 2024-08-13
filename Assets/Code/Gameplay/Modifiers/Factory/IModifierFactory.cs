namespace AbilityMadness.Code.Gameplay.Modifiers.Factory
{
    public interface IModifierFactory
    {
        GameEntity CreateModifier(GameEntity gameEntity, ModifierTypeId type, float value);
    }
}
