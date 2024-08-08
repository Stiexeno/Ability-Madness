//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Bogenbai.CustomGenerators.Plugins.CustomComponentEntityApiGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public partial class GameEntity {

    static readonly AbilityMadness.Code.Gameplay.Health.HealthbarLoading healthbarLoadingComponent = new AbilityMadness.Code.Gameplay.Health.HealthbarLoading();

    public bool isHealthbarLoading {
        get { return HasComponent(GameComponentsLookup.HealthbarLoading); }
        set {
            if (value != isHealthbarLoading) {
                var index = GameComponentsLookup.HealthbarLoading;
                if (value) {
                    var componentPool = GetComponentPool(index);
                    var component = componentPool.Count > 0
                            ? componentPool.Pop()
                            : healthbarLoadingComponent;

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

    static Entitas.IMatcher<GameEntity> _matcherHealthbarLoading;

    public static Entitas.IMatcher<GameEntity> HealthbarLoading {
        get {
            if (_matcherHealthbarLoading == null) {
                var matcher = (Entitas.Matcher<GameEntity>)Entitas.Matcher<GameEntity>.AllOf(GameComponentsLookup.HealthbarLoading);
                matcher.componentNames = GameComponentsLookup.componentNames;
                _matcherHealthbarLoading = matcher;
            }

            return _matcherHealthbarLoading;
        }
    }
}