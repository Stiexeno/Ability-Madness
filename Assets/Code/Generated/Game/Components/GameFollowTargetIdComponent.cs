//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Bogenbai.CustomGenerators.Plugins.CustomComponentEntityApiGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public partial class GameEntity {

    private AbilityMadness.Code.Gameplay.Camera.FollowTargetId followTargetId { get { return (AbilityMadness.Code.Gameplay.Camera.FollowTargetId)GetComponent(GameComponentsLookup.FollowTargetId); } }
    public int FollowTargetId { get { return followTargetId.Value; } set { followTargetId.Value = value; }}
    public bool hasFollowTargetId { get { return HasComponent(GameComponentsLookup.FollowTargetId); } }

    public GameEntity AddFollowTargetId(int newValue) {
        var index = GameComponentsLookup.FollowTargetId;
        var component = (AbilityMadness.Code.Gameplay.Camera.FollowTargetId)CreateComponent(index, typeof(AbilityMadness.Code.Gameplay.Camera.FollowTargetId));
        component.Value = newValue;
        AddComponent(index, component);

        return this;
    }

    public GameEntity ReactiveReplaceFollowTargetId(int newValue) {
        var index = GameComponentsLookup.FollowTargetId;
        var component = (AbilityMadness.Code.Gameplay.Camera.FollowTargetId)CreateComponent(index, typeof(AbilityMadness.Code.Gameplay.Camera.FollowTargetId));
        component.Value = newValue;
        ReplaceComponent(index, component);

        return this;
    }

    public GameEntity ReplaceFollowTargetId(int newValue) {
        if (!hasFollowTargetId) 
        {
            AddFollowTargetId(newValue);
            return this;
        }

        followTargetId.Value = newValue;
        return this;
    }

    public GameEntity RemoveFollowTargetId() {
        RemoveComponent(GameComponentsLookup.FollowTargetId);
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

    static Entitas.IMatcher<GameEntity> _matcherFollowTargetId;

    public static Entitas.IMatcher<GameEntity> FollowTargetId {
        get {
            if (_matcherFollowTargetId == null) {
                var matcher = (Entitas.Matcher<GameEntity>)Entitas.Matcher<GameEntity>.AllOf(GameComponentsLookup.FollowTargetId);
                matcher.componentNames = GameComponentsLookup.componentNames;
                _matcherFollowTargetId = matcher;
            }

            return _matcherFollowTargetId;
        }
    }
}