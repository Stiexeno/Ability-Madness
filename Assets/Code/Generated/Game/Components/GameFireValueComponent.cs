//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Bogenbai.CustomGenerators.Plugins.CustomComponentEntityApiGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public partial class GameEntity {

    private AbilityMadness.Code.Gameplay.Modifiers.FireValue fireValue { get { return (AbilityMadness.Code.Gameplay.Modifiers.FireValue)GetComponent(GameComponentsLookup.FireValue); } }
    public float FireValue { get { return fireValue.Value; } set { fireValue.Value = value; }}
    public bool hasFireValue { get { return HasComponent(GameComponentsLookup.FireValue); } }

    public GameEntity AddFireValue(float newValue) {
        var index = GameComponentsLookup.FireValue;
        var component = (AbilityMadness.Code.Gameplay.Modifiers.FireValue)CreateComponent(index, typeof(AbilityMadness.Code.Gameplay.Modifiers.FireValue));
        component.Value = newValue;
        AddComponent(index, component);

        return this;
    }

    public GameEntity ReactiveReplaceFireValue(float newValue) {
        var index = GameComponentsLookup.FireValue;
        var component = (AbilityMadness.Code.Gameplay.Modifiers.FireValue)CreateComponent(index, typeof(AbilityMadness.Code.Gameplay.Modifiers.FireValue));
        component.Value = newValue;
        ReplaceComponent(index, component);

        return this;
    }

    public GameEntity ReplaceFireValue(float newValue) {
        if (!hasFireValue) 
        {
            AddFireValue(newValue);
            return this;
        }

        fireValue.Value = newValue;
        return this;
    }

    public GameEntity RemoveFireValue() {
        RemoveComponent(GameComponentsLookup.FireValue);
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

    static Entitas.IMatcher<GameEntity> _matcherFireValue;

    public static Entitas.IMatcher<GameEntity> FireValue {
        get {
            if (_matcherFireValue == null) {
                var matcher = (Entitas.Matcher<GameEntity>)Entitas.Matcher<GameEntity>.AllOf(GameComponentsLookup.FireValue);
                matcher.componentNames = GameComponentsLookup.componentNames;
                _matcherFireValue = matcher;
            }

            return _matcherFireValue;
        }
    }
}
