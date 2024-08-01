//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Bogenbai.CustomGenerators.Plugins.CustomComponentEntityApiGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public partial class GameEntity {

    private AbilityMadness.Code.Gameplay.Vision.VisionRadius visionRadius { get { return (AbilityMadness.Code.Gameplay.Vision.VisionRadius)GetComponent(GameComponentsLookup.VisionRadius); } }
    public float VisionRadius { get { return visionRadius.Value; } set { visionRadius.Value = value; }}
    public bool hasVisionRadius { get { return HasComponent(GameComponentsLookup.VisionRadius); } }

    public GameEntity AddVisionRadius(float newValue) {
        var index = GameComponentsLookup.VisionRadius;
        var component = (AbilityMadness.Code.Gameplay.Vision.VisionRadius)CreateComponent(index, typeof(AbilityMadness.Code.Gameplay.Vision.VisionRadius));
        component.Value = newValue;
        AddComponent(index, component);

        return this;
    }

    public GameEntity ReactiveReplaceVisionRadius(float newValue) {
        var index = GameComponentsLookup.VisionRadius;
        var component = (AbilityMadness.Code.Gameplay.Vision.VisionRadius)CreateComponent(index, typeof(AbilityMadness.Code.Gameplay.Vision.VisionRadius));
        component.Value = newValue;
        ReplaceComponent(index, component);

        return this;
    }

    public GameEntity ReplaceVisionRadius(float newValue) {
        if (!hasVisionRadius) 
        {
            AddVisionRadius(newValue);
            return this;
        }

        visionRadius.Value = newValue;
        return this;
    }

    public GameEntity RemoveVisionRadius() {
        RemoveComponent(GameComponentsLookup.VisionRadius);
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

    static Entitas.IMatcher<GameEntity> _matcherVisionRadius;

    public static Entitas.IMatcher<GameEntity> VisionRadius {
        get {
            if (_matcherVisionRadius == null) {
                var matcher = (Entitas.Matcher<GameEntity>)Entitas.Matcher<GameEntity>.AllOf(GameComponentsLookup.VisionRadius);
                matcher.componentNames = GameComponentsLookup.componentNames;
                _matcherVisionRadius = matcher;
            }

            return _matcherVisionRadius;
        }
    }
}
