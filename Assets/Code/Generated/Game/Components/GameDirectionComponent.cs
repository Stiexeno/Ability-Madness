//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Bogenbai.CustomGenerators.Plugins.CustomComponentEntityApiGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public partial class GameEntity {

    private AbilityMadness.Code.Gameplay.Movement.Direction direction { get { return (AbilityMadness.Code.Gameplay.Movement.Direction)GetComponent(GameComponentsLookup.Direction); } }
    public UnityEngine.Vector2 Direction { get { return direction.Value; } set { direction.Value = value; }}
    public bool hasDirection { get { return HasComponent(GameComponentsLookup.Direction); } }

    public GameEntity AddDirection(UnityEngine.Vector2 newValue) {
        var index = GameComponentsLookup.Direction;
        var component = (AbilityMadness.Code.Gameplay.Movement.Direction)CreateComponent(index, typeof(AbilityMadness.Code.Gameplay.Movement.Direction));
        component.Value = newValue;
        AddComponent(index, component);

        return this;
    }

    public GameEntity ReactiveReplaceDirection(UnityEngine.Vector2 newValue) {
        var index = GameComponentsLookup.Direction;
        var component = (AbilityMadness.Code.Gameplay.Movement.Direction)CreateComponent(index, typeof(AbilityMadness.Code.Gameplay.Movement.Direction));
        component.Value = newValue;
        ReplaceComponent(index, component);

        return this;
    }

    public GameEntity ReplaceDirection(UnityEngine.Vector2 newValue) {
        if (!hasDirection) 
        {
            AddDirection(newValue);
            return this;
        }

        direction.Value = newValue;
        return this;
    }

    public GameEntity RemoveDirection() {
        RemoveComponent(GameComponentsLookup.Direction);
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

    static Entitas.IMatcher<GameEntity> _matcherDirection;

    public static Entitas.IMatcher<GameEntity> Direction {
        get {
            if (_matcherDirection == null) {
                var matcher = (Entitas.Matcher<GameEntity>)Entitas.Matcher<GameEntity>.AllOf(GameComponentsLookup.Direction);
                matcher.componentNames = GameComponentsLookup.componentNames;
                _matcherDirection = matcher;
            }

            return _matcherDirection;
        }
    }
}
