//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Bogenbai.CustomGenerators.Plugins.CustomComponentEntityApiGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public partial class GameEntity {

    static readonly AbilityMadness.Code.Gameplay.Projectile.Throwable.Throwable throwableComponent = new AbilityMadness.Code.Gameplay.Projectile.Throwable.Throwable();

    public bool isThrowable {
        get { return HasComponent(GameComponentsLookup.Throwable); }
        set {
            if (value != isThrowable) {
                var index = GameComponentsLookup.Throwable;
                if (value) {
                    var componentPool = GetComponentPool(index);
                    var component = componentPool.Count > 0
                            ? componentPool.Pop()
                            : throwableComponent;

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

    static Entitas.IMatcher<GameEntity> _matcherThrowable;

    public static Entitas.IMatcher<GameEntity> Throwable {
        get {
            if (_matcherThrowable == null) {
                var matcher = (Entitas.Matcher<GameEntity>)Entitas.Matcher<GameEntity>.AllOf(GameComponentsLookup.Throwable);
                matcher.componentNames = GameComponentsLookup.componentNames;
                _matcherThrowable = matcher;
            }

            return _matcherThrowable;
        }
    }
}
