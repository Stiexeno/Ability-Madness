//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Bogenbai.CustomGenerators.Plugins.CustomComponentEntityApiGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using AbilityMadness.Code.Gameplay.Enemy.Waves;

public partial class GameEntity {

    static readonly Wave waveComponent = new Wave();

    public bool isWave {
        get { return HasComponent(GameComponentsLookup.Wave); }
        set {
            if (value != isWave) {
                var index = GameComponentsLookup.Wave;
                if (value) {
                    var componentPool = GetComponentPool(index);
                    var component = componentPool.Count > 0
                            ? componentPool.Pop()
                            : waveComponent;

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

    static Entitas.IMatcher<GameEntity> _matcherWave;

    public static Entitas.IMatcher<GameEntity> Wave {
        get {
            if (_matcherWave == null) {
                var matcher = (Entitas.Matcher<GameEntity>)Entitas.Matcher<GameEntity>.AllOf(GameComponentsLookup.Wave);
                matcher.componentNames = GameComponentsLookup.componentNames;
                _matcherWave = matcher;
            }

            return _matcherWave;
        }
    }
}
