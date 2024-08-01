//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Bogenbai.CustomGenerators.Plugins.CustomComponentEntityApiGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public partial class GameEntity {

    private AbilityMadness.Code.Gameplay.Health.MaxHealth maxHealth { get { return (AbilityMadness.Code.Gameplay.Health.MaxHealth)GetComponent(GameComponentsLookup.MaxHealth); } }
    public int MaxHealth { get { return maxHealth.Value; } set { maxHealth.Value = value; }}
    public bool hasMaxHealth { get { return HasComponent(GameComponentsLookup.MaxHealth); } }

    public GameEntity AddMaxHealth(int newValue) {
        var index = GameComponentsLookup.MaxHealth;
        var component = (AbilityMadness.Code.Gameplay.Health.MaxHealth)CreateComponent(index, typeof(AbilityMadness.Code.Gameplay.Health.MaxHealth));
        component.Value = newValue;
        AddComponent(index, component);

        return this;
    }

    public GameEntity ReactiveReplaceMaxHealth(int newValue) {
        var index = GameComponentsLookup.MaxHealth;
        var component = (AbilityMadness.Code.Gameplay.Health.MaxHealth)CreateComponent(index, typeof(AbilityMadness.Code.Gameplay.Health.MaxHealth));
        component.Value = newValue;
        ReplaceComponent(index, component);

        return this;
    }

    public GameEntity ReplaceMaxHealth(int newValue) {
        if (!hasMaxHealth) 
        {
            AddMaxHealth(newValue);
            return this;
        }

        maxHealth.Value = newValue;
        return this;
    }

    public GameEntity RemoveMaxHealth() {
        RemoveComponent(GameComponentsLookup.MaxHealth);
        return this;
    }
}

//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentMatcherApiGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public sealed partial class GameMatcher {

    static Entitas.IMatcher<GameEntity> _matcherMaxHealth;

    public static Entitas.IMatcher<GameEntity> MaxHealth {
        get {
            if (_matcherMaxHealth == null) {
                var matcher = (Entitas.Matcher<GameEntity>)Entitas.Matcher<GameEntity>.AllOf(GameComponentsLookup.MaxHealth);
                matcher.componentNames = GameComponentsLookup.componentNames;
                _matcherMaxHealth = matcher;
            }

            return _matcherMaxHealth;
        }
    }
}
