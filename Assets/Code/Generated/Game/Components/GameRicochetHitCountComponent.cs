//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Bogenbai.CustomGenerators.Plugins.CustomComponentEntityApiGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public partial class GameEntity {

    private AbilityMadness.Code.Gameplay.Modifiers.RicochetHitCount ricochetHitCount { get { return (AbilityMadness.Code.Gameplay.Modifiers.RicochetHitCount)GetComponent(GameComponentsLookup.RicochetHitCount); } }
    public int RicochetHitCount { get { return ricochetHitCount.Value; } set { ricochetHitCount.Value = value; }}
    public bool hasRicochetHitCount { get { return HasComponent(GameComponentsLookup.RicochetHitCount); } }

    public GameEntity AddRicochetHitCount(int newValue) {
        var index = GameComponentsLookup.RicochetHitCount;
        var component = (AbilityMadness.Code.Gameplay.Modifiers.RicochetHitCount)CreateComponent(index, typeof(AbilityMadness.Code.Gameplay.Modifiers.RicochetHitCount));
        component.Value = newValue;
        AddComponent(index, component);

        return this;
    }

    public GameEntity ReactiveReplaceRicochetHitCount(int newValue) {
        var index = GameComponentsLookup.RicochetHitCount;
        var component = (AbilityMadness.Code.Gameplay.Modifiers.RicochetHitCount)CreateComponent(index, typeof(AbilityMadness.Code.Gameplay.Modifiers.RicochetHitCount));
        component.Value = newValue;
        ReplaceComponent(index, component);

        return this;
    }

    public GameEntity ReplaceRicochetHitCount(int newValue) {
        if (!hasRicochetHitCount) 
        {
            AddRicochetHitCount(newValue);
            return this;
        }

        ricochetHitCount.Value = newValue;
        return this;
    }

    public GameEntity RemoveRicochetHitCount() {
        RemoveComponent(GameComponentsLookup.RicochetHitCount);
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

    static Entitas.IMatcher<GameEntity> _matcherRicochetHitCount;

    public static Entitas.IMatcher<GameEntity> RicochetHitCount {
        get {
            if (_matcherRicochetHitCount == null) {
                var matcher = (Entitas.Matcher<GameEntity>)Entitas.Matcher<GameEntity>.AllOf(GameComponentsLookup.RicochetHitCount);
                matcher.componentNames = GameComponentsLookup.componentNames;
                _matcherRicochetHitCount = matcher;
            }

            return _matcherRicochetHitCount;
        }
    }
}
