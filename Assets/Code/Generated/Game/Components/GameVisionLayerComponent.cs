//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Bogenbai.CustomGenerators.Plugins.CustomComponentEntityApiGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public partial class GameEntity {

    private AbilityMadness.Code.Gameplay.Vision.VisionLayer visionLayer { get { return (AbilityMadness.Code.Gameplay.Vision.VisionLayer)GetComponent(GameComponentsLookup.VisionLayer); } }
    public int VisionLayer { get { return visionLayer.Value; } set { visionLayer.Value = value; }}
    public bool hasVisionLayer { get { return HasComponent(GameComponentsLookup.VisionLayer); } }

    public GameEntity AddVisionLayer(int newValue) {
        var index = GameComponentsLookup.VisionLayer;
        var component = (AbilityMadness.Code.Gameplay.Vision.VisionLayer)CreateComponent(index, typeof(AbilityMadness.Code.Gameplay.Vision.VisionLayer));
        component.Value = newValue;
        AddComponent(index, component);

        return this;
    }

    public GameEntity ReactiveReplaceVisionLayer(int newValue) {
        var index = GameComponentsLookup.VisionLayer;
        var component = (AbilityMadness.Code.Gameplay.Vision.VisionLayer)CreateComponent(index, typeof(AbilityMadness.Code.Gameplay.Vision.VisionLayer));
        component.Value = newValue;
        ReplaceComponent(index, component);

        return this;
    }

    public GameEntity ReplaceVisionLayer(int newValue) {
        if (!hasVisionLayer) 
        {
            AddVisionLayer(newValue);
            return this;
        }

        visionLayer.Value = newValue;
        return this;
    }

    public GameEntity RemoveVisionLayer() {
        RemoveComponent(GameComponentsLookup.VisionLayer);
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

    static Entitas.IMatcher<GameEntity> _matcherVisionLayer;

    public static Entitas.IMatcher<GameEntity> VisionLayer {
        get {
            if (_matcherVisionLayer == null) {
                var matcher = (Entitas.Matcher<GameEntity>)Entitas.Matcher<GameEntity>.AllOf(GameComponentsLookup.VisionLayer);
                matcher.componentNames = GameComponentsLookup.componentNames;
                _matcherVisionLayer = matcher;
            }

            return _matcherVisionLayer;
        }
    }
}
