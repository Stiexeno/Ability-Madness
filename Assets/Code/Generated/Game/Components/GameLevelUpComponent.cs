//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Bogenbai.CustomGenerators.Plugins.CustomComponentEntityApiGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public partial class GameEntity {

    static readonly AbilityMadness.Code.Gameplay.Experience.LevelUp levelUpComponent = new AbilityMadness.Code.Gameplay.Experience.LevelUp();

    public bool isLevelUp {
        get { return HasComponent(GameComponentsLookup.LevelUp); }
        set {
            if (value != isLevelUp) {
                var index = GameComponentsLookup.LevelUp;
                if (value) {
                    var componentPool = GetComponentPool(index);
                    var component = componentPool.Count > 0
                            ? componentPool.Pop()
                            : levelUpComponent;

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

    static Entitas.IMatcher<GameEntity> _matcherLevelUp;

    public static Entitas.IMatcher<GameEntity> LevelUp {
        get {
            if (_matcherLevelUp == null) {
                var matcher = (Entitas.Matcher<GameEntity>)Entitas.Matcher<GameEntity>.AllOf(GameComponentsLookup.LevelUp);
                matcher.componentNames = GameComponentsLookup.componentNames;
                _matcherLevelUp = matcher;
            }

            return _matcherLevelUp;
        }
    }
}
