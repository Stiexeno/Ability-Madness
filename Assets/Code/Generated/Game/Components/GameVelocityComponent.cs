//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Bogenbai.CustomGenerators.Plugins.CustomComponentEntityApiGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public partial class GameEntity {

    private AbilityMadness.Code.Gameplay.Movement.Velocity velocity { get { return (AbilityMadness.Code.Gameplay.Movement.Velocity)GetComponent(GameComponentsLookup.Velocity); } }
    public UnityEngine.Vector2 Velocity { get { return velocity.Value; } set { velocity.Value = value; }}
    public bool hasVelocity { get { return HasComponent(GameComponentsLookup.Velocity); } }

    public GameEntity AddVelocity(UnityEngine.Vector2 newValue) {
        var index = GameComponentsLookup.Velocity;
        var component = (AbilityMadness.Code.Gameplay.Movement.Velocity)CreateComponent(index, typeof(AbilityMadness.Code.Gameplay.Movement.Velocity));
        component.Value = newValue;
        AddComponent(index, component);

        return this;
    }

    public GameEntity ReactiveReplaceVelocity(UnityEngine.Vector2 newValue) {
        var index = GameComponentsLookup.Velocity;
        var component = (AbilityMadness.Code.Gameplay.Movement.Velocity)CreateComponent(index, typeof(AbilityMadness.Code.Gameplay.Movement.Velocity));
        component.Value = newValue;
        ReplaceComponent(index, component);

        return this;
    }

    public GameEntity ReplaceVelocity(UnityEngine.Vector2 newValue) {
        if (!hasVelocity) 
        {
            AddVelocity(newValue);
            return this;
        }

        velocity.Value = newValue;
        return this;
    }

    public GameEntity RemoveVelocity() {
        RemoveComponent(GameComponentsLookup.Velocity);
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

    static Entitas.IMatcher<GameEntity> _matcherVelocity;

    public static Entitas.IMatcher<GameEntity> Velocity {
        get {
            if (_matcherVelocity == null) {
                var matcher = (Entitas.Matcher<GameEntity>)Entitas.Matcher<GameEntity>.AllOf(GameComponentsLookup.Velocity);
                matcher.componentNames = GameComponentsLookup.componentNames;
                _matcherVelocity = matcher;
            }

            return _matcherVelocity;
        }
    }
}
