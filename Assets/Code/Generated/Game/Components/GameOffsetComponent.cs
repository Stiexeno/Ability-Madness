//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Bogenbai.CustomGenerators.Plugins.CustomComponentEntityApiGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public partial class GameEntity {

    private AbilityMadness.Code.Common.Offset offset { get { return (AbilityMadness.Code.Common.Offset)GetComponent(GameComponentsLookup.Offset); } }
    public UnityEngine.Vector3 Offset { get { return offset.Value; } set { offset.Value = value; }}
    public bool hasOffset { get { return HasComponent(GameComponentsLookup.Offset); } }

    public GameEntity AddOffset(UnityEngine.Vector3 newValue) {
        var index = GameComponentsLookup.Offset;
        var component = (AbilityMadness.Code.Common.Offset)CreateComponent(index, typeof(AbilityMadness.Code.Common.Offset));
        component.Value = newValue;
        AddComponent(index, component);

        return this;
    }

    public GameEntity ReactiveReplaceOffset(UnityEngine.Vector3 newValue) {
        var index = GameComponentsLookup.Offset;
        var component = (AbilityMadness.Code.Common.Offset)CreateComponent(index, typeof(AbilityMadness.Code.Common.Offset));
        component.Value = newValue;
        ReplaceComponent(index, component);

        return this;
    }

    public GameEntity ReplaceOffset(UnityEngine.Vector3 newValue) {
        if (!hasOffset) 
        {
            AddOffset(newValue);
            return this;
        }

        offset.Value = newValue;
        return this;
    }

    public GameEntity RemoveOffset() {
        RemoveComponent(GameComponentsLookup.Offset);
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

    static Entitas.IMatcher<GameEntity> _matcherOffset;

    public static Entitas.IMatcher<GameEntity> Offset {
        get {
            if (_matcherOffset == null) {
                var matcher = (Entitas.Matcher<GameEntity>)Entitas.Matcher<GameEntity>.AllOf(GameComponentsLookup.Offset);
                matcher.componentNames = GameComponentsLookup.componentNames;
                _matcherOffset = matcher;
            }

            return _matcherOffset;
        }
    }
}