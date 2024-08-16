//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Bogenbai.CustomGenerators.Plugins.CustomComponentEntityApiGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public partial class GameEntity {

    private AbilityMadness.Code.Gameplay.TargetCollection.TargetLayer targetLayer { get { return (AbilityMadness.Code.Gameplay.TargetCollection.TargetLayer)GetComponent(GameComponentsLookup.TargetLayer); } }
    public int TargetLayer { get { return targetLayer.Value; } set { targetLayer.Value = value; }}
    public bool hasTargetLayer { get { return HasComponent(GameComponentsLookup.TargetLayer); } }

    public GameEntity AddTargetLayer(int newValue) {
        var index = GameComponentsLookup.TargetLayer;
        var component = (AbilityMadness.Code.Gameplay.TargetCollection.TargetLayer)CreateComponent(index, typeof(AbilityMadness.Code.Gameplay.TargetCollection.TargetLayer));
        component.Value = newValue;
        AddComponent(index, component);

        return this;
    }

    public GameEntity ReactiveReplaceTargetLayer(int newValue) {
        var index = GameComponentsLookup.TargetLayer;
        var component = (AbilityMadness.Code.Gameplay.TargetCollection.TargetLayer)CreateComponent(index, typeof(AbilityMadness.Code.Gameplay.TargetCollection.TargetLayer));
        component.Value = newValue;
        ReplaceComponent(index, component);

        return this;
    }

    public GameEntity ReplaceTargetLayer(int newValue) {
        if (!hasTargetLayer) 
        {
            AddTargetLayer(newValue);
            return this;
        }

        targetLayer.Value = newValue;
        return this;
    }

    public GameEntity RemoveTargetLayer() {
        RemoveComponent(GameComponentsLookup.TargetLayer);
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

    static Entitas.IMatcher<GameEntity> _matcherTargetLayer;

    public static Entitas.IMatcher<GameEntity> TargetLayer {
        get {
            if (_matcherTargetLayer == null) {
                var matcher = (Entitas.Matcher<GameEntity>)Entitas.Matcher<GameEntity>.AllOf(GameComponentsLookup.TargetLayer);
                matcher.componentNames = GameComponentsLookup.componentNames;
                _matcherTargetLayer = matcher;
            }

            return _matcherTargetLayer;
        }
    }
}
