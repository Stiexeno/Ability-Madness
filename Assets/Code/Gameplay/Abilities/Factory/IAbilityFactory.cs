namespace AbilityMadness.Code.Gameplay.Abilities.Factory
{
    public interface IAbilityFactory
    {
        GameEntity CreateAbility(GameEntity owner, AbilityTypeId type);
    }
}
