//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Bogenbai.CustomGenerators.Plugins.CustomComponentEntityApiGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public partial class GameEntity {

    private AbilityMadness.Code.Gameplay.Status.StatusSetupComponent statusSetup { get { return (AbilityMadness.Code.Gameplay.Status.StatusSetupComponent)GetComponent(GameComponentsLookup.StatusSetup); } }
    public AbilityMadness.Code.Gameplay.Status.Factory.StatusSetup StatusSetup { get { return statusSetup.Value; } set { statusSetup.Value = value; }}
    public bool hasStatusSetup { get { return HasComponent(GameComponentsLookup.StatusSetup); } }

    public GameEntity AddStatusSetup(AbilityMadness.Code.Gameplay.Status.Factory.StatusSetup newValue) {
        var index = GameComponentsLookup.StatusSetup;
        var component = (AbilityMadness.Code.Gameplay.Status.StatusSetupComponent)CreateComponent(index, typeof(AbilityMadness.Code.Gameplay.Status.StatusSetupComponent));
        component.Value = newValue;
        AddComponent(index, component);

        return this;
    }

    public GameEntity ReactiveReplaceStatusSetup(AbilityMadness.Code.Gameplay.Status.Factory.StatusSetup newValue) {
        var index = GameComponentsLookup.StatusSetup;
        var component = (AbilityMadness.Code.Gameplay.Status.StatusSetupComponent)CreateComponent(index, typeof(AbilityMadness.Code.Gameplay.Status.StatusSetupComponent));
        component.Value = newValue;
        ReplaceComponent(index, component);

        return this;
    }

    public GameEntity ReplaceStatusSetup(AbilityMadness.Code.Gameplay.Status.Factory.StatusSetup newValue) {
        if (!hasStatusSetup) 
        {
            AddStatusSetup(newValue);
            return this;
        }

        statusSetup.Value = newValue;
        return this;
    }

    public GameEntity RemoveStatusSetup() {
        RemoveComponent(GameComponentsLookup.StatusSetup);
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

    static Entitas.IMatcher<GameEntity> _matcherStatusSetup;

    public static Entitas.IMatcher<GameEntity> StatusSetup {
        get {
            if (_matcherStatusSetup == null) {
                var matcher = (Entitas.Matcher<GameEntity>)Entitas.Matcher<GameEntity>.AllOf(GameComponentsLookup.StatusSetup);
                matcher.componentNames = GameComponentsLookup.componentNames;
                _matcherStatusSetup = matcher;
            }

            return _matcherStatusSetup;
        }
    }
}
