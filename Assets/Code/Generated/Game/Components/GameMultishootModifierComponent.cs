//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Bogenbai.CustomGenerators.Plugins.CustomComponentEntityApiGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public partial class GameEntity {

    static readonly AbilityMadness.Code.Gameplay.Modifiers.MultishootModifier multishootModifierComponent = new AbilityMadness.Code.Gameplay.Modifiers.MultishootModifier();

    public bool isMultishootModifier {
        get { return HasComponent(GameComponentsLookup.MultishootModifier); }
        set {
            if (value != isMultishootModifier) {
                var index = GameComponentsLookup.MultishootModifier;
                if (value) {
                    var componentPool = GetComponentPool(index);
                    var component = componentPool.Count > 0
                            ? componentPool.Pop()
                            : multishootModifierComponent;

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

    static Entitas.IMatcher<GameEntity> _matcherMultishootModifier;

    public static Entitas.IMatcher<GameEntity> MultishootModifier {
        get {
            if (_matcherMultishootModifier == null) {
                var matcher = (Entitas.Matcher<GameEntity>)Entitas.Matcher<GameEntity>.AllOf(GameComponentsLookup.MultishootModifier);
                matcher.componentNames = GameComponentsLookup.componentNames;
                _matcherMultishootModifier = matcher;
            }

            return _matcherMultishootModifier;
        }
    }
}