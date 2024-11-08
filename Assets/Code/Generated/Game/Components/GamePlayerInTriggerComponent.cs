//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Bogenbai.CustomGenerators.Plugins.CustomComponentEntityApiGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public partial class GameEntity {

    static readonly AbilityMadness.PlayerInTrigger playerInTriggerComponent = new AbilityMadness.PlayerInTrigger();

    public bool isPlayerInTrigger {
        get { return HasComponent(GameComponentsLookup.PlayerInTrigger); }
        set {
            if (value != isPlayerInTrigger) {
                var index = GameComponentsLookup.PlayerInTrigger;
                if (value) {
                    var componentPool = GetComponentPool(index);
                    var component = componentPool.Count > 0
                            ? componentPool.Pop()
                            : playerInTriggerComponent;

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

    static Entitas.IMatcher<GameEntity> _matcherPlayerInTrigger;

    public static Entitas.IMatcher<GameEntity> PlayerInTrigger {
        get {
            if (_matcherPlayerInTrigger == null) {
                var matcher = (Entitas.Matcher<GameEntity>)Entitas.Matcher<GameEntity>.AllOf(GameComponentsLookup.PlayerInTrigger);
                matcher.componentNames = GameComponentsLookup.componentNames;
                _matcherPlayerInTrigger = matcher;
            }

            return _matcherPlayerInTrigger;
        }
    }
}
