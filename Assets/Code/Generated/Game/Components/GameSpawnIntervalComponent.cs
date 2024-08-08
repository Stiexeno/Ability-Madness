//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Bogenbai.CustomGenerators.Plugins.CustomComponentEntityApiGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public partial class GameEntity {

    private AbilityMadness.Code.Common.SpawnInterval spawnInterval { get { return (AbilityMadness.Code.Common.SpawnInterval)GetComponent(GameComponentsLookup.SpawnInterval); } }
    public float SpawnInterval { get { return spawnInterval.Value; } set { spawnInterval.Value = value; }}
    public bool hasSpawnInterval { get { return HasComponent(GameComponentsLookup.SpawnInterval); } }

    public GameEntity AddSpawnInterval(float newValue) {
        var index = GameComponentsLookup.SpawnInterval;
        var component = (AbilityMadness.Code.Common.SpawnInterval)CreateComponent(index, typeof(AbilityMadness.Code.Common.SpawnInterval));
        component.Value = newValue;
        AddComponent(index, component);

        return this;
    }

    public GameEntity ReactiveReplaceSpawnInterval(float newValue) {
        var index = GameComponentsLookup.SpawnInterval;
        var component = (AbilityMadness.Code.Common.SpawnInterval)CreateComponent(index, typeof(AbilityMadness.Code.Common.SpawnInterval));
        component.Value = newValue;
        ReplaceComponent(index, component);

        return this;
    }

    public GameEntity ReplaceSpawnInterval(float newValue) {
        if (!hasSpawnInterval) 
        {
            AddSpawnInterval(newValue);
            return this;
        }

        spawnInterval.Value = newValue;
        return this;
    }

    public GameEntity RemoveSpawnInterval() {
        RemoveComponent(GameComponentsLookup.SpawnInterval);
        return this;
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

    static Entitas.IMatcher<GameEntity> _matcherSpawnInterval;

    public static Entitas.IMatcher<GameEntity> SpawnInterval {
        get {
            if (_matcherSpawnInterval == null) {
                var matcher = (Entitas.Matcher<GameEntity>)Entitas.Matcher<GameEntity>.AllOf(GameComponentsLookup.SpawnInterval);
                matcher.componentNames = GameComponentsLookup.componentNames;
                _matcherSpawnInterval = matcher;
            }

            return _matcherSpawnInterval;
        }
    }
}