//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Bogenbai.CustomGenerators.Plugins.CustomComponentEntityApiGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public partial class GameEntity {

    private AbilityMadness.Code.Gameplay.Status.StatusSetups statusSetups { get { return (AbilityMadness.Code.Gameplay.Status.StatusSetups)GetComponent(GameComponentsLookup.StatusSetups); } }
    public System.Collections.Generic.List<AbilityMadness.Code.Gameplay.Status.Factory.StatusSetup> StatusSetups { get { return statusSetups.Value; } set { statusSetups.Value = value; }}
    public bool hasStatusSetups { get { return HasComponent(GameComponentsLookup.StatusSetups); } }

    public GameEntity AddStatusSetups(System.Collections.Generic.List<AbilityMadness.Code.Gameplay.Status.Factory.StatusSetup> newValue) {
        var index = GameComponentsLookup.StatusSetups;
        var component = (AbilityMadness.Code.Gameplay.Status.StatusSetups)CreateComponent(index, typeof(AbilityMadness.Code.Gameplay.Status.StatusSetups));
        component.Value = newValue;
        AddComponent(index, component);

        return this;
    }

    public GameEntity ReactiveReplaceStatusSetups(System.Collections.Generic.List<AbilityMadness.Code.Gameplay.Status.Factory.StatusSetup> newValue) {
        var index = GameComponentsLookup.StatusSetups;
        var component = (AbilityMadness.Code.Gameplay.Status.StatusSetups)CreateComponent(index, typeof(AbilityMadness.Code.Gameplay.Status.StatusSetups));
        component.Value = newValue;
        ReplaceComponent(index, component);

        return this;
    }

    public GameEntity ReplaceStatusSetups(System.Collections.Generic.List<AbilityMadness.Code.Gameplay.Status.Factory.StatusSetup> newValue) {
        if (!hasStatusSetups) 
        {
            AddStatusSetups(newValue);
            return this;
        }

        statusSetups.Value = newValue;
        return this;
    }

    public GameEntity RemoveStatusSetups() {
        RemoveComponent(GameComponentsLookup.StatusSetups);
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

    static Entitas.IMatcher<GameEntity> _matcherStatusSetups;

    public static Entitas.IMatcher<GameEntity> StatusSetups {
        get {
            if (_matcherStatusSetups == null) {
                var matcher = (Entitas.Matcher<GameEntity>)Entitas.Matcher<GameEntity>.AllOf(GameComponentsLookup.StatusSetups);
                matcher.componentNames = GameComponentsLookup.componentNames;
                _matcherStatusSetups = matcher;
            }

            return _matcherStatusSetups;
        }
    }
}
