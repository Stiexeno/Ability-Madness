//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Bogenbai.CustomGenerators.Plugins.CustomComponentEntityApiGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public partial class GameEntity {

    static readonly AbilityMadness.Code.Gameplay.Modifiers.LifeStealModifier lifeStealModifierComponent = new AbilityMadness.Code.Gameplay.Modifiers.LifeStealModifier();

    public bool isLifeStealModifier {
        get { return HasComponent(GameComponentsLookup.LifeStealModifier); }
        set {
            if (value != isLifeStealModifier) {
                var index = GameComponentsLookup.LifeStealModifier;
                if (value) {
                    var componentPool = GetComponentPool(index);
                    var component = componentPool.Count > 0
                            ? componentPool.Pop()
                            : lifeStealModifierComponent;

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

    static Entitas.IMatcher<GameEntity> _matcherLifeStealModifier;

    public static Entitas.IMatcher<GameEntity> LifeStealModifier {
        get {
            if (_matcherLifeStealModifier == null) {
                var matcher = (Entitas.Matcher<GameEntity>)Entitas.Matcher<GameEntity>.AllOf(GameComponentsLookup.LifeStealModifier);
                matcher.componentNames = GameComponentsLookup.componentNames;
                _matcherLifeStealModifier = matcher;
            }

            return _matcherLifeStealModifier;
        }
    }
}
