//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Bogenbai.CustomGenerators.Plugins.CustomComponentEntityApiGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public partial class GameEntity {

    private AbilityMadness.Code.Gameplay.Trails.TrailTypeIdComponent trailTypeId { get { return (AbilityMadness.Code.Gameplay.Trails.TrailTypeIdComponent)GetComponent(GameComponentsLookup.TrailTypeId); } }
    public AbilityMadness.Code.Gameplay.Trails.TrailTypeId TrailTypeId { get { return trailTypeId.Value; } set { trailTypeId.Value = value; }}
    public bool hasTrailTypeId { get { return HasComponent(GameComponentsLookup.TrailTypeId); } }

    public GameEntity AddTrailTypeId(AbilityMadness.Code.Gameplay.Trails.TrailTypeId newValue) {
        var index = GameComponentsLookup.TrailTypeId;
        var component = (AbilityMadness.Code.Gameplay.Trails.TrailTypeIdComponent)CreateComponent(index, typeof(AbilityMadness.Code.Gameplay.Trails.TrailTypeIdComponent));
        component.Value = newValue;
        AddComponent(index, component);

        return this;
    }

    public GameEntity ReactiveReplaceTrailTypeId(AbilityMadness.Code.Gameplay.Trails.TrailTypeId newValue) {
        var index = GameComponentsLookup.TrailTypeId;
        var component = (AbilityMadness.Code.Gameplay.Trails.TrailTypeIdComponent)CreateComponent(index, typeof(AbilityMadness.Code.Gameplay.Trails.TrailTypeIdComponent));
        component.Value = newValue;
        ReplaceComponent(index, component);

        return this;
    }

    public GameEntity ReplaceTrailTypeId(AbilityMadness.Code.Gameplay.Trails.TrailTypeId newValue) {
        if (!hasTrailTypeId) 
        {
            AddTrailTypeId(newValue);
            return this;
        }

        trailTypeId.Value = newValue;
        return this;
    }

    public GameEntity RemoveTrailTypeId() {
        RemoveComponent(GameComponentsLookup.TrailTypeId);
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

    static Entitas.IMatcher<GameEntity> _matcherTrailTypeId;

    public static Entitas.IMatcher<GameEntity> TrailTypeId {
        get {
            if (_matcherTrailTypeId == null) {
                var matcher = (Entitas.Matcher<GameEntity>)Entitas.Matcher<GameEntity>.AllOf(GameComponentsLookup.TrailTypeId);
                matcher.componentNames = GameComponentsLookup.componentNames;
                _matcherTrailTypeId = matcher;
            }

            return _matcherTrailTypeId;
        }
    }
}
