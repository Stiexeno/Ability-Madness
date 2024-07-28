//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Bogenbai.CustomGenerators.Plugins.CustomComponentEntityApiGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public partial class GameEntity {

    static readonly AbilityMadness.Code.Common.Disabled disabledComponent = new AbilityMadness.Code.Common.Disabled();

    public bool isDisabled {
        get { return HasComponent(GameComponentsLookup.Disabled); }
        set {
            if (value != isDisabled) {
                var index = GameComponentsLookup.Disabled;
                if (value) {
                    var componentPool = GetComponentPool(index);
                    var component = componentPool.Count > 0
                            ? componentPool.Pop()
                            : disabledComponent;

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

    static Entitas.IMatcher<GameEntity> _matcherDisabled;

    public static Entitas.IMatcher<GameEntity> Disabled {
        get {
            if (_matcherDisabled == null) {
                var matcher = (Entitas.Matcher<GameEntity>)Entitas.Matcher<GameEntity>.AllOf(GameComponentsLookup.Disabled);
                matcher.componentNames = GameComponentsLookup.componentNames;
                _matcherDisabled = matcher;
            }

            return _matcherDisabled;
        }
    }
}
