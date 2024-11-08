//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Bogenbai.CustomGenerators.Plugins.CustomComponentEntityApiGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public partial class GameEntity {

    private AbilityMadness.Code.Gameplay.Weapons.Spread spread { get { return (AbilityMadness.Code.Gameplay.Weapons.Spread)GetComponent(GameComponentsLookup.Spread); } }
    public float Spread { get { return spread.Value; } set { spread.Value = value; }}
    public bool hasSpread { get { return HasComponent(GameComponentsLookup.Spread); } }

    public GameEntity AddSpread(float newValue) {
        var index = GameComponentsLookup.Spread;
        var component = (AbilityMadness.Code.Gameplay.Weapons.Spread)CreateComponent(index, typeof(AbilityMadness.Code.Gameplay.Weapons.Spread));
        component.Value = newValue;
        AddComponent(index, component);

        return this;
    }

    public GameEntity ReactiveReplaceSpread(float newValue) {
        var index = GameComponentsLookup.Spread;
        var component = (AbilityMadness.Code.Gameplay.Weapons.Spread)CreateComponent(index, typeof(AbilityMadness.Code.Gameplay.Weapons.Spread));
        component.Value = newValue;
        ReplaceComponent(index, component);

        return this;
    }

    public GameEntity ReplaceSpread(float newValue) {
        if (!hasSpread) 
        {
            AddSpread(newValue);
            return this;
        }

        spread.Value = newValue;
        return this;
    }

    public GameEntity RemoveSpread() {
        RemoveComponent(GameComponentsLookup.Spread);
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

    static Entitas.IMatcher<GameEntity> _matcherSpread;

    public static Entitas.IMatcher<GameEntity> Spread {
        get {
            if (_matcherSpread == null) {
                var matcher = (Entitas.Matcher<GameEntity>)Entitas.Matcher<GameEntity>.AllOf(GameComponentsLookup.Spread);
                matcher.componentNames = GameComponentsLookup.componentNames;
                _matcherSpread = matcher;
            }

            return _matcherSpread;
        }
    }
}
