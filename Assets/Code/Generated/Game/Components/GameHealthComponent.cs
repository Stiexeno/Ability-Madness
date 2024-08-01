//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Bogenbai.CustomGenerators.Plugins.CustomComponentEntityApiGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public partial class GameEntity {

    private AbilityMadness.Code.Gameplay.Health.Health health { get { return (AbilityMadness.Code.Gameplay.Health.Health)GetComponent(GameComponentsLookup.Health); } }
    public int Health { get { return health.Value; } set { health.Value = value; }}
    public bool hasHealth { get { return HasComponent(GameComponentsLookup.Health); } }

    public GameEntity AddHealth(int newValue) {
        var index = GameComponentsLookup.Health;
        var component = (AbilityMadness.Code.Gameplay.Health.Health)CreateComponent(index, typeof(AbilityMadness.Code.Gameplay.Health.Health));
        component.Value = newValue;
        AddComponent(index, component);

        return this;
    }

    public GameEntity ReactiveReplaceHealth(int newValue) {
        var index = GameComponentsLookup.Health;
        var component = (AbilityMadness.Code.Gameplay.Health.Health)CreateComponent(index, typeof(AbilityMadness.Code.Gameplay.Health.Health));
        component.Value = newValue;
        ReplaceComponent(index, component);

        return this;
    }

    public GameEntity ReplaceHealth(int newValue) {
        if (!hasHealth) 
        {
            AddHealth(newValue);
            return this;
        }

        health.Value = newValue;
        return this;
    }

    public GameEntity RemoveHealth() {
        RemoveComponent(GameComponentsLookup.Health);
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

    static Entitas.IMatcher<GameEntity> _matcherHealth;

    public static Entitas.IMatcher<GameEntity> Health {
        get {
            if (_matcherHealth == null) {
                var matcher = (Entitas.Matcher<GameEntity>)Entitas.Matcher<GameEntity>.AllOf(GameComponentsLookup.Health);
                matcher.componentNames = GameComponentsLookup.componentNames;
                _matcherHealth = matcher;
            }

            return _matcherHealth;
        }
    }
}
