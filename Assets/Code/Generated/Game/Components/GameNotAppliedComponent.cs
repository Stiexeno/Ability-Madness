//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Bogenbai.CustomGenerators.Plugins.CustomComponentEntityApiGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public partial class GameEntity {

    static readonly AbilityMadness.Code.Gameplay.Gears.NotApplied notAppliedComponent = new AbilityMadness.Code.Gameplay.Gears.NotApplied();

    public bool isNotApplied {
        get { return HasComponent(GameComponentsLookup.NotApplied); }
        set {
            if (value != isNotApplied) {
                var index = GameComponentsLookup.NotApplied;
                if (value) {
                    var componentPool = GetComponentPool(index);
                    var component = componentPool.Count > 0
                            ? componentPool.Pop()
                            : notAppliedComponent;

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

    static Entitas.IMatcher<GameEntity> _matcherNotApplied;

    public static Entitas.IMatcher<GameEntity> NotApplied {
        get {
            if (_matcherNotApplied == null) {
                var matcher = (Entitas.Matcher<GameEntity>)Entitas.Matcher<GameEntity>.AllOf(GameComponentsLookup.NotApplied);
                matcher.componentNames = GameComponentsLookup.componentNames;
                _matcherNotApplied = matcher;
            }

            return _matcherNotApplied;
        }
    }
}