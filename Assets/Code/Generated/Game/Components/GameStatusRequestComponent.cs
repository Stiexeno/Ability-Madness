//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Bogenbai.CustomGenerators.Plugins.CustomComponentEntityApiGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public partial class GameEntity {

    static readonly AbilityMadness.Code.Gameplay.Status.StatusRequest statusRequestComponent = new AbilityMadness.Code.Gameplay.Status.StatusRequest();

    public bool isStatusRequest {
        get { return HasComponent(GameComponentsLookup.StatusRequest); }
        set {
            if (value != isStatusRequest) {
                var index = GameComponentsLookup.StatusRequest;
                if (value) {
                    var componentPool = GetComponentPool(index);
                    var component = componentPool.Count > 0
                            ? componentPool.Pop()
                            : statusRequestComponent;

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

    static Entitas.IMatcher<GameEntity> _matcherStatusRequest;

    public static Entitas.IMatcher<GameEntity> StatusRequest {
        get {
            if (_matcherStatusRequest == null) {
                var matcher = (Entitas.Matcher<GameEntity>)Entitas.Matcher<GameEntity>.AllOf(GameComponentsLookup.StatusRequest);
                matcher.componentNames = GameComponentsLookup.componentNames;
                _matcherStatusRequest = matcher;
            }

            return _matcherStatusRequest;
        }
    }
}
