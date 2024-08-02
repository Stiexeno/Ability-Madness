//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Bogenbai.CustomGenerators.Plugins.CustomComponentEntityApiGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public partial class GameEntity {

    static readonly AbilityMadness.Code.Gameplay.Modifiers.SpeedModifier speedModifierComponent = new AbilityMadness.Code.Gameplay.Modifiers.SpeedModifier();

    public bool isSpeedModifier {
        get { return HasComponent(GameComponentsLookup.SpeedModifier); }
        set {
            if (value != isSpeedModifier) {
                var index = GameComponentsLookup.SpeedModifier;
                if (value) {
                    var componentPool = GetComponentPool(index);
                    var component = componentPool.Count > 0
                            ? componentPool.Pop()
                            : speedModifierComponent;

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

    static Entitas.IMatcher<GameEntity> _matcherSpeedModifier;

    public static Entitas.IMatcher<GameEntity> SpeedModifier {
        get {
            if (_matcherSpeedModifier == null) {
                var matcher = (Entitas.Matcher<GameEntity>)Entitas.Matcher<GameEntity>.AllOf(GameComponentsLookup.SpeedModifier);
                matcher.componentNames = GameComponentsLookup.componentNames;
                _matcherSpeedModifier = matcher;
            }

            return _matcherSpeedModifier;
        }
    }
}