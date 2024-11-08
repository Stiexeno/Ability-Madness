//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Bogenbai.CustomGenerators.Plugins.CustomComponentEntityApiGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public partial class GameEntity {

    private AbilityMadness.Code.Gameplay.Movement.DashDuration dashDuration { get { return (AbilityMadness.Code.Gameplay.Movement.DashDuration)GetComponent(GameComponentsLookup.DashDuration); } }
    public float DashDuration { get { return dashDuration.Value; } set { dashDuration.Value = value; }}
    public bool hasDashDuration { get { return HasComponent(GameComponentsLookup.DashDuration); } }

    public GameEntity AddDashDuration(float newValue) {
        var index = GameComponentsLookup.DashDuration;
        var component = (AbilityMadness.Code.Gameplay.Movement.DashDuration)CreateComponent(index, typeof(AbilityMadness.Code.Gameplay.Movement.DashDuration));
        component.Value = newValue;
        AddComponent(index, component);

        return this;
    }

    public GameEntity ReactiveReplaceDashDuration(float newValue) {
        var index = GameComponentsLookup.DashDuration;
        var component = (AbilityMadness.Code.Gameplay.Movement.DashDuration)CreateComponent(index, typeof(AbilityMadness.Code.Gameplay.Movement.DashDuration));
        component.Value = newValue;
        ReplaceComponent(index, component);

        return this;
    }

    public GameEntity ReplaceDashDuration(float newValue) {
        if (!hasDashDuration) 
        {
            AddDashDuration(newValue);
            return this;
        }

        dashDuration.Value = newValue;
        return this;
    }

    public GameEntity RemoveDashDuration() {
        RemoveComponent(GameComponentsLookup.DashDuration);
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

    static Entitas.IMatcher<GameEntity> _matcherDashDuration;

    public static Entitas.IMatcher<GameEntity> DashDuration {
        get {
            if (_matcherDashDuration == null) {
                var matcher = (Entitas.Matcher<GameEntity>)Entitas.Matcher<GameEntity>.AllOf(GameComponentsLookup.DashDuration);
                matcher.componentNames = GameComponentsLookup.componentNames;
                _matcherDashDuration = matcher;
            }

            return _matcherDashDuration;
        }
    }
}
