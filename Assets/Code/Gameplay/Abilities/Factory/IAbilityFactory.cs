using AbilityMadness.Code.Gameplay.Abilities.Configs;

namespace AbilityMadness.Code.Gameplay.Abilities.Factory
{
    public interface IAbilityFactory
    {
        GameEntity CreateFireball(GameEntity owner, AbilityConfig abilityConfig);
        GameEntity CreateArrow(GameEntity owner, AbilityConfig abilityConfig);
        GameEntity CreateAbility(GameEntity owner, AbilityTypeId type);
    }
}
