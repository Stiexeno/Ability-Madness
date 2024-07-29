//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Bogenbai.CustomGenerators.Plugins.CustomComponentEntityApiGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public partial class GameEntity {

    static readonly AbilityMadness.Code.Common.Collision.CollisionEnter collisionEnterComponent = new AbilityMadness.Code.Common.Collision.CollisionEnter();

    public bool isCollisionEnter {
        get { return HasComponent(GameComponentsLookup.CollisionEnter); }
        set {
            if (value != isCollisionEnter) {
                var index = GameComponentsLookup.CollisionEnter;
                if (value) {
                    var componentPool = GetComponentPool(index);
                    var component = componentPool.Count > 0
                            ? componentPool.Pop()
                            : collisionEnterComponent;

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

    static Entitas.IMatcher<GameEntity> _matcherCollisionEnter;

    public static Entitas.IMatcher<GameEntity> CollisionEnter {
        get {
            if (_matcherCollisionEnter == null) {
                var matcher = (Entitas.Matcher<GameEntity>)Entitas.Matcher<GameEntity>.AllOf(GameComponentsLookup.CollisionEnter);
                matcher.componentNames = GameComponentsLookup.componentNames;
                _matcherCollisionEnter = matcher;
            }

            return _matcherCollisionEnter;
        }
    }
}
