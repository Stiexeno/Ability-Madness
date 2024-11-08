//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Bogenbai.CustomGenerators.Plugins.CustomComponentEntityApiGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public partial class GameEntity {

    static readonly AbilityMadness.Code.Common.Enabled enabledComponent = new AbilityMadness.Code.Common.Enabled();

    public bool isEnabled {
        get { return HasComponent(GameComponentsLookup.Enabled); }
        set {
            if (value != isEnabled) {
                var index = GameComponentsLookup.Enabled;
                if (value) {
                    var componentPool = GetComponentPool(index);
                    var component = componentPool.Count > 0
                            ? componentPool.Pop()
                            : enabledComponent;

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

    static Entitas.IMatcher<GameEntity> _matcherEnabled;

    public static Entitas.IMatcher<GameEntity> Enabled {
        get {
            if (_matcherEnabled == null) {
                var matcher = (Entitas.Matcher<GameEntity>)Entitas.Matcher<GameEntity>.AllOf(GameComponentsLookup.Enabled);
                matcher.componentNames = GameComponentsLookup.componentNames;
                _matcherEnabled = matcher;
            }

            return _matcherEnabled;
        }
    }
}
