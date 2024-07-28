//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Bogenbai.CustomGenerators.Plugins.CustomComponentEntityApiGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public partial class GameEntity {

    private AbilityMadness.Code.Gameplay.Camera.CameraSmooth cameraSmooth { get { return (AbilityMadness.Code.Gameplay.Camera.CameraSmooth)GetComponent(GameComponentsLookup.CameraSmooth); } }
    public float CameraSmooth { get { return cameraSmooth.Value; } set { cameraSmooth.Value = value; }}
    public bool hasCameraSmooth { get { return HasComponent(GameComponentsLookup.CameraSmooth); } }

    public GameEntity AddCameraSmooth(float newValue) {
        var index = GameComponentsLookup.CameraSmooth;
        var component = (AbilityMadness.Code.Gameplay.Camera.CameraSmooth)CreateComponent(index, typeof(AbilityMadness.Code.Gameplay.Camera.CameraSmooth));
        component.Value = newValue;
        AddComponent(index, component);

        return this;
    }

    public GameEntity ReactiveReplaceCameraSmooth(float newValue) {
        var index = GameComponentsLookup.CameraSmooth;
        var component = (AbilityMadness.Code.Gameplay.Camera.CameraSmooth)CreateComponent(index, typeof(AbilityMadness.Code.Gameplay.Camera.CameraSmooth));
        component.Value = newValue;
        ReplaceComponent(index, component);

        return this;
    }

    public GameEntity ReplaceCameraSmooth(float newValue) {
        if (!hasCameraSmooth) 
        {
            AddCameraSmooth(newValue);
            return this;
        }

        cameraSmooth.Value = newValue;
        return this;
    }

    public GameEntity RemoveCameraSmooth() {
        RemoveComponent(GameComponentsLookup.CameraSmooth);
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

    static Entitas.IMatcher<GameEntity> _matcherCameraSmooth;

    public static Entitas.IMatcher<GameEntity> CameraSmooth {
        get {
            if (_matcherCameraSmooth == null) {
                var matcher = (Entitas.Matcher<GameEntity>)Entitas.Matcher<GameEntity>.AllOf(GameComponentsLookup.CameraSmooth);
                matcher.componentNames = GameComponentsLookup.componentNames;
                _matcherCameraSmooth = matcher;
            }

            return _matcherCameraSmooth;
        }
    }
}
