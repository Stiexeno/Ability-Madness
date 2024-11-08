//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Bogenbai.CustomGenerators.Plugins.CustomComponentEntityApiGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public partial class GameEntity {

    private AbilityMadness.Code.Gameplay.Movement.LastPosition lastPosition { get { return (AbilityMadness.Code.Gameplay.Movement.LastPosition)GetComponent(GameComponentsLookup.LastPosition); } }
    public UnityEngine.Vector3 LastPosition { get { return lastPosition.Value; } set { lastPosition.Value = value; }}
    public bool hasLastPosition { get { return HasComponent(GameComponentsLookup.LastPosition); } }

    public GameEntity AddLastPosition(UnityEngine.Vector3 newValue) {
        var index = GameComponentsLookup.LastPosition;
        var component = (AbilityMadness.Code.Gameplay.Movement.LastPosition)CreateComponent(index, typeof(AbilityMadness.Code.Gameplay.Movement.LastPosition));
        component.Value = newValue;
        AddComponent(index, component);

        return this;
    }

    public GameEntity ReactiveReplaceLastPosition(UnityEngine.Vector3 newValue) {
        var index = GameComponentsLookup.LastPosition;
        var component = (AbilityMadness.Code.Gameplay.Movement.LastPosition)CreateComponent(index, typeof(AbilityMadness.Code.Gameplay.Movement.LastPosition));
        component.Value = newValue;
        ReplaceComponent(index, component);

        return this;
    }

    public GameEntity ReplaceLastPosition(UnityEngine.Vector3 newValue) {
        if (!hasLastPosition) 
        {
            AddLastPosition(newValue);
            return this;
        }

        lastPosition.Value = newValue;
        return this;
    }

    public GameEntity RemoveLastPosition() {
        RemoveComponent(GameComponentsLookup.LastPosition);
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

    static Entitas.IMatcher<GameEntity> _matcherLastPosition;

    public static Entitas.IMatcher<GameEntity> LastPosition {
        get {
            if (_matcherLastPosition == null) {
                var matcher = (Entitas.Matcher<GameEntity>)Entitas.Matcher<GameEntity>.AllOf(GameComponentsLookup.LastPosition);
                matcher.componentNames = GameComponentsLookup.componentNames;
                _matcherLastPosition = matcher;
            }

            return _matcherLastPosition;
        }
    }
}
