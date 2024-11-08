//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Bogenbai.CustomGenerators.Plugins.CustomComponentEntityApiGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public partial class GameEntity {

    private AbilityMadness.Code.Gameplay.EffectApplication.EffectTypeIdComponent effectTypeId { get { return (AbilityMadness.Code.Gameplay.EffectApplication.EffectTypeIdComponent)GetComponent(GameComponentsLookup.EffectTypeId); } }
    public AbilityMadness.Code.Gameplay.EffectApplication.EffectTypeId EffectTypeId { get { return effectTypeId.Value; } set { effectTypeId.Value = value; }}
    public bool hasEffectTypeId { get { return HasComponent(GameComponentsLookup.EffectTypeId); } }

    public GameEntity AddEffectTypeId(AbilityMadness.Code.Gameplay.EffectApplication.EffectTypeId newValue) {
        var index = GameComponentsLookup.EffectTypeId;
        var component = (AbilityMadness.Code.Gameplay.EffectApplication.EffectTypeIdComponent)CreateComponent(index, typeof(AbilityMadness.Code.Gameplay.EffectApplication.EffectTypeIdComponent));
        component.Value = newValue;
        AddComponent(index, component);

        return this;
    }

    public GameEntity ReactiveReplaceEffectTypeId(AbilityMadness.Code.Gameplay.EffectApplication.EffectTypeId newValue) {
        var index = GameComponentsLookup.EffectTypeId;
        var component = (AbilityMadness.Code.Gameplay.EffectApplication.EffectTypeIdComponent)CreateComponent(index, typeof(AbilityMadness.Code.Gameplay.EffectApplication.EffectTypeIdComponent));
        component.Value = newValue;
        ReplaceComponent(index, component);

        return this;
    }

    public GameEntity ReplaceEffectTypeId(AbilityMadness.Code.Gameplay.EffectApplication.EffectTypeId newValue) {
        if (!hasEffectTypeId) 
        {
            AddEffectTypeId(newValue);
            return this;
        }

        effectTypeId.Value = newValue;
        return this;
    }

    public GameEntity RemoveEffectTypeId() {
        RemoveComponent(GameComponentsLookup.EffectTypeId);
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

    static Entitas.IMatcher<GameEntity> _matcherEffectTypeId;

    public static Entitas.IMatcher<GameEntity> EffectTypeId {
        get {
            if (_matcherEffectTypeId == null) {
                var matcher = (Entitas.Matcher<GameEntity>)Entitas.Matcher<GameEntity>.AllOf(GameComponentsLookup.EffectTypeId);
                matcher.componentNames = GameComponentsLookup.componentNames;
                _matcherEffectTypeId = matcher;
            }

            return _matcherEffectTypeId;
        }
    }
}
