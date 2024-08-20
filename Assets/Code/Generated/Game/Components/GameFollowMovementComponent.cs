//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Bogenbai.CustomGenerators.Plugins.CustomComponentEntityApiGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public partial class GameEntity {

    static readonly AbilityMadness.Code.Gameplay.Movement.FollowMovement followMovementComponent = new AbilityMadness.Code.Gameplay.Movement.FollowMovement();

    public bool isFollowMovement {
        get { return HasComponent(GameComponentsLookup.FollowMovement); }
        set {
            if (value != isFollowMovement) {
                var index = GameComponentsLookup.FollowMovement;
                if (value) {
                    var componentPool = GetComponentPool(index);
                    var component = componentPool.Count > 0
                            ? componentPool.Pop()
                            : followMovementComponent;

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

    static Entitas.IMatcher<GameEntity> _matcherFollowMovement;

    public static Entitas.IMatcher<GameEntity> FollowMovement {
        get {
            if (_matcherFollowMovement == null) {
                var matcher = (Entitas.Matcher<GameEntity>)Entitas.Matcher<GameEntity>.AllOf(GameComponentsLookup.FollowMovement);
                matcher.componentNames = GameComponentsLookup.componentNames;
                _matcherFollowMovement = matcher;
            }

            return _matcherFollowMovement;
        }
    }
}
