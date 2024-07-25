//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentEntityApiGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public partial class GameEntity {

    static readonly AbilityMadness.Code.Gameplay.Movement.TransformMovement transformMovementComponent = new AbilityMadness.Code.Gameplay.Movement.TransformMovement();

    public bool isTransformMovement {
        get { return HasComponent(GameComponentsLookup.TransformMovement); }
        set {
            if (value != isTransformMovement) {
                var index = GameComponentsLookup.TransformMovement;
                if (value) {
                    var componentPool = GetComponentPool(index);
                    var component = componentPool.Count > 0
                            ? componentPool.Pop()
                            : transformMovementComponent;

                    AddComponent(index, component);
                } else {
                    RemoveComponent(index);
                }
            }
        }
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

    static Entitas.IMatcher<GameEntity> _matcherTransformMovement;

    public static Entitas.IMatcher<GameEntity> TransformMovement {
        get {
            if (_matcherTransformMovement == null) {
                var matcher = (Entitas.Matcher<GameEntity>)Entitas.Matcher<GameEntity>.AllOf(GameComponentsLookup.TransformMovement);
                matcher.componentNames = GameComponentsLookup.componentNames;
                _matcherTransformMovement = matcher;
            }

            return _matcherTransformMovement;
        }
    }
}
