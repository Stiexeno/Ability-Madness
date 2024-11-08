//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Bogenbai.CustomGenerators.Plugins.CustomComponentEntityApiGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public partial class GameEntity {

    private AbilityMadness.Code.Gameplay.Experience.MaxExperience maxExperience { get { return (AbilityMadness.Code.Gameplay.Experience.MaxExperience)GetComponent(GameComponentsLookup.MaxExperience); } }
    public int MaxExperience { get { return maxExperience.Value; } set { maxExperience.Value = value; }}
    public bool hasMaxExperience { get { return HasComponent(GameComponentsLookup.MaxExperience); } }

    public GameEntity AddMaxExperience(int newValue) {
        var index = GameComponentsLookup.MaxExperience;
        var component = (AbilityMadness.Code.Gameplay.Experience.MaxExperience)CreateComponent(index, typeof(AbilityMadness.Code.Gameplay.Experience.MaxExperience));
        component.Value = newValue;
        AddComponent(index, component);

        return this;
    }

    public GameEntity ReactiveReplaceMaxExperience(int newValue) {
        var index = GameComponentsLookup.MaxExperience;
        var component = (AbilityMadness.Code.Gameplay.Experience.MaxExperience)CreateComponent(index, typeof(AbilityMadness.Code.Gameplay.Experience.MaxExperience));
        component.Value = newValue;
        ReplaceComponent(index, component);

        return this;
    }

    public GameEntity ReplaceMaxExperience(int newValue) {
        if (!hasMaxExperience) 
        {
            AddMaxExperience(newValue);
            return this;
        }

        maxExperience.Value = newValue;
        return this;
    }

    public GameEntity RemoveMaxExperience() {
        RemoveComponent(GameComponentsLookup.MaxExperience);
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

    static Entitas.IMatcher<GameEntity> _matcherMaxExperience;

    public static Entitas.IMatcher<GameEntity> MaxExperience {
        get {
            if (_matcherMaxExperience == null) {
                var matcher = (Entitas.Matcher<GameEntity>)Entitas.Matcher<GameEntity>.AllOf(GameComponentsLookup.MaxExperience);
                matcher.componentNames = GameComponentsLookup.componentNames;
                _matcherMaxExperience = matcher;
            }

            return _matcherMaxExperience;
        }
    }
}
