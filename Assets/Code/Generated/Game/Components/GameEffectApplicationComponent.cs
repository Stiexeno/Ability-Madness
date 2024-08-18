//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Bogenbai.CustomGenerators.Plugins.CustomComponentEntityApiGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public partial class GameEntity {

    static readonly AbilityMadness.Code.Gameplay.EffectApplication.EffectApplication effectApplicationComponent = new AbilityMadness.Code.Gameplay.EffectApplication.EffectApplication();

    public bool isEffectApplication {
        get { return HasComponent(GameComponentsLookup.EffectApplication); }
        set {
            if (value != isEffectApplication) {
                var index = GameComponentsLookup.EffectApplication;
                if (value) {
                    var componentPool = GetComponentPool(index);
                    var component = componentPool.Count > 0
                            ? componentPool.Pop()
                            : effectApplicationComponent;

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

    static Entitas.IMatcher<GameEntity> _matcherEffectApplication;

    public static Entitas.IMatcher<GameEntity> EffectApplication {
        get {
            if (_matcherEffectApplication == null) {
                var matcher = (Entitas.Matcher<GameEntity>)Entitas.Matcher<GameEntity>.AllOf(GameComponentsLookup.EffectApplication);
                matcher.componentNames = GameComponentsLookup.componentNames;
                _matcherEffectApplication = matcher;
            }

            return _matcherEffectApplication;
        }
    }
}