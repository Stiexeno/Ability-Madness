//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Bogenbai.CustomGenerators.Plugins.CustomComponentEntityApiGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public partial class GameEntity {

    private AbilityMadness.Code.Gameplay.Area.AreaTypeIdComponent areaTypeId { get { return (AbilityMadness.Code.Gameplay.Area.AreaTypeIdComponent)GetComponent(GameComponentsLookup.AreaTypeId); } }
    public AbilityMadness.Code.Gameplay.Area.AreaTypeId AreaTypeId { get { return areaTypeId.Value; } set { areaTypeId.Value = value; }}
    public bool hasAreaTypeId { get { return HasComponent(GameComponentsLookup.AreaTypeId); } }

    public GameEntity AddAreaTypeId(AbilityMadness.Code.Gameplay.Area.AreaTypeId newValue) {
        var index = GameComponentsLookup.AreaTypeId;
        var component = (AbilityMadness.Code.Gameplay.Area.AreaTypeIdComponent)CreateComponent(index, typeof(AbilityMadness.Code.Gameplay.Area.AreaTypeIdComponent));
        component.Value = newValue;
        AddComponent(index, component);

        return this;
    }

    public GameEntity ReactiveReplaceAreaTypeId(AbilityMadness.Code.Gameplay.Area.AreaTypeId newValue) {
        var index = GameComponentsLookup.AreaTypeId;
        var component = (AbilityMadness.Code.Gameplay.Area.AreaTypeIdComponent)CreateComponent(index, typeof(AbilityMadness.Code.Gameplay.Area.AreaTypeIdComponent));
        component.Value = newValue;
        ReplaceComponent(index, component);

        return this;
    }

    public GameEntity ReplaceAreaTypeId(AbilityMadness.Code.Gameplay.Area.AreaTypeId newValue) {
        if (!hasAreaTypeId) 
        {
            AddAreaTypeId(newValue);
            return this;
        }

        areaTypeId.Value = newValue;
        return this;
    }

    public GameEntity RemoveAreaTypeId() {
        RemoveComponent(GameComponentsLookup.AreaTypeId);
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

    static Entitas.IMatcher<GameEntity> _matcherAreaTypeId;

    public static Entitas.IMatcher<GameEntity> AreaTypeId {
        get {
            if (_matcherAreaTypeId == null) {
                var matcher = (Entitas.Matcher<GameEntity>)Entitas.Matcher<GameEntity>.AllOf(GameComponentsLookup.AreaTypeId);
                matcher.componentNames = GameComponentsLookup.componentNames;
                _matcherAreaTypeId = matcher;
            }

            return _matcherAreaTypeId;
        }
    }
}
