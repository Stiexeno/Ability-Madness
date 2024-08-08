//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Bogenbai.CustomGenerators.Plugins.CustomComponentEntityApiGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public partial class GameEntity {

    private AbilityMadness.Code.Gameplay.Experience.PickupRadius pickupRadius { get { return (AbilityMadness.Code.Gameplay.Experience.PickupRadius)GetComponent(GameComponentsLookup.PickupRadius); } }
    public float PickupRadius { get { return pickupRadius.Value; } set { pickupRadius.Value = value; }}
    public bool hasPickupRadius { get { return HasComponent(GameComponentsLookup.PickupRadius); } }

    public GameEntity AddPickupRadius(float newValue) {
        var index = GameComponentsLookup.PickupRadius;
        var component = (AbilityMadness.Code.Gameplay.Experience.PickupRadius)CreateComponent(index, typeof(AbilityMadness.Code.Gameplay.Experience.PickupRadius));
        component.Value = newValue;
        AddComponent(index, component);

        return this;
    }

    public GameEntity ReactiveReplacePickupRadius(float newValue) {
        var index = GameComponentsLookup.PickupRadius;
        var component = (AbilityMadness.Code.Gameplay.Experience.PickupRadius)CreateComponent(index, typeof(AbilityMadness.Code.Gameplay.Experience.PickupRadius));
        component.Value = newValue;
        ReplaceComponent(index, component);

        return this;
    }

    public GameEntity ReplacePickupRadius(float newValue) {
        if (!hasPickupRadius) 
        {
            AddPickupRadius(newValue);
            return this;
        }

        pickupRadius.Value = newValue;
        return this;
    }

    public GameEntity RemovePickupRadius() {
        RemoveComponent(GameComponentsLookup.PickupRadius);
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

    static Entitas.IMatcher<GameEntity> _matcherPickupRadius;

    public static Entitas.IMatcher<GameEntity> PickupRadius {
        get {
            if (_matcherPickupRadius == null) {
                var matcher = (Entitas.Matcher<GameEntity>)Entitas.Matcher<GameEntity>.AllOf(GameComponentsLookup.PickupRadius);
                matcher.componentNames = GameComponentsLookup.componentNames;
                _matcherPickupRadius = matcher;
            }

            return _matcherPickupRadius;
        }
    }
}