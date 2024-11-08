//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Bogenbai.CustomGenerators.Plugins.CustomComponentEntityApiGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public partial class GameEntity {

    private AbilityMadness.Code.Gameplay.Lifetime.LifeTime lifeTime { get { return (AbilityMadness.Code.Gameplay.Lifetime.LifeTime)GetComponent(GameComponentsLookup.LifeTime); } }
    public float LifeTime { get { return lifeTime.Value; } set { lifeTime.Value = value; }}
    public bool hasLifeTime { get { return HasComponent(GameComponentsLookup.LifeTime); } }

    public GameEntity AddLifeTime(float newValue) {
        var index = GameComponentsLookup.LifeTime;
        var component = (AbilityMadness.Code.Gameplay.Lifetime.LifeTime)CreateComponent(index, typeof(AbilityMadness.Code.Gameplay.Lifetime.LifeTime));
        component.Value = newValue;
        AddComponent(index, component);

        return this;
    }

    public GameEntity ReactiveReplaceLifeTime(float newValue) {
        var index = GameComponentsLookup.LifeTime;
        var component = (AbilityMadness.Code.Gameplay.Lifetime.LifeTime)CreateComponent(index, typeof(AbilityMadness.Code.Gameplay.Lifetime.LifeTime));
        component.Value = newValue;
        ReplaceComponent(index, component);

        return this;
    }

    public GameEntity ReplaceLifeTime(float newValue) {
        if (!hasLifeTime) 
        {
            AddLifeTime(newValue);
            return this;
        }

        lifeTime.Value = newValue;
        return this;
    }

    public GameEntity RemoveLifeTime() {
        RemoveComponent(GameComponentsLookup.LifeTime);
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

    static Entitas.IMatcher<GameEntity> _matcherLifeTime;

    public static Entitas.IMatcher<GameEntity> LifeTime {
        get {
            if (_matcherLifeTime == null) {
                var matcher = (Entitas.Matcher<GameEntity>)Entitas.Matcher<GameEntity>.AllOf(GameComponentsLookup.LifeTime);
                matcher.componentNames = GameComponentsLookup.componentNames;
                _matcherLifeTime = matcher;
            }

            return _matcherLifeTime;
        }
    }
}
