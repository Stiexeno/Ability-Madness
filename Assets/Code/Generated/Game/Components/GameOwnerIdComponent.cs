//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Bogenbai.CustomGenerators.Plugins.CustomComponentEntityApiGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public partial class GameEntity {

    private AbilityMadness.Code.Common.OwnerId ownerId { get { return (AbilityMadness.Code.Common.OwnerId)GetComponent(GameComponentsLookup.OwnerId); } }
    public int OwnerId { get { return ownerId.Value; } set { ownerId.Value = value; }}
    public bool hasOwnerId { get { return HasComponent(GameComponentsLookup.OwnerId); } }

    public GameEntity AddOwnerId(int newValue) {
        var index = GameComponentsLookup.OwnerId;
        var component = (AbilityMadness.Code.Common.OwnerId)CreateComponent(index, typeof(AbilityMadness.Code.Common.OwnerId));
        component.Value = newValue;
        AddComponent(index, component);

        return this;
    }

    public GameEntity ReactiveReplaceOwnerId(int newValue) {
        var index = GameComponentsLookup.OwnerId;
        var component = (AbilityMadness.Code.Common.OwnerId)CreateComponent(index, typeof(AbilityMadness.Code.Common.OwnerId));
        component.Value = newValue;
        ReplaceComponent(index, component);

        return this;
    }

    public GameEntity ReplaceOwnerId(int newValue) {
        if (!hasOwnerId) 
        {
            AddOwnerId(newValue);
            return this;
        }

        ownerId.Value = newValue;
        return this;
    }

    public GameEntity RemoveOwnerId() {
        RemoveComponent(GameComponentsLookup.OwnerId);
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

    static Entitas.IMatcher<GameEntity> _matcherOwnerId;

    public static Entitas.IMatcher<GameEntity> OwnerId {
        get {
            if (_matcherOwnerId == null) {
                var matcher = (Entitas.Matcher<GameEntity>)Entitas.Matcher<GameEntity>.AllOf(GameComponentsLookup.OwnerId);
                matcher.componentNames = GameComponentsLookup.componentNames;
                _matcherOwnerId = matcher;
            }

            return _matcherOwnerId;
        }
    }
}