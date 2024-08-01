//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Bogenbai.CustomGenerators.Plugins.CustomComponentEntityApiGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public partial class GameEntity {

    private AbilityMadness.Code.Gameplay.EffectApplication.EffectViewPath effectViewPath { get { return (AbilityMadness.Code.Gameplay.EffectApplication.EffectViewPath)GetComponent(GameComponentsLookup.EffectViewPath); } }
    public string EffectViewPath { get { return effectViewPath.Value; } set { effectViewPath.Value = value; }}
    public bool hasEffectViewPath { get { return HasComponent(GameComponentsLookup.EffectViewPath); } }

    public GameEntity AddEffectViewPath(string newValue) {
        var index = GameComponentsLookup.EffectViewPath;
        var component = (AbilityMadness.Code.Gameplay.EffectApplication.EffectViewPath)CreateComponent(index, typeof(AbilityMadness.Code.Gameplay.EffectApplication.EffectViewPath));
        component.Value = newValue;
        AddComponent(index, component);

        return this;
    }

    public GameEntity ReactiveReplaceEffectViewPath(string newValue) {
        var index = GameComponentsLookup.EffectViewPath;
        var component = (AbilityMadness.Code.Gameplay.EffectApplication.EffectViewPath)CreateComponent(index, typeof(AbilityMadness.Code.Gameplay.EffectApplication.EffectViewPath));
        component.Value = newValue;
        ReplaceComponent(index, component);

        return this;
    }

    public GameEntity ReplaceEffectViewPath(string newValue) {
        if (!hasEffectViewPath) 
        {
            AddEffectViewPath(newValue);
            return this;
        }

        effectViewPath.Value = newValue;
        return this;
    }

    public GameEntity RemoveEffectViewPath() {
        RemoveComponent(GameComponentsLookup.EffectViewPath);
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

    static Entitas.IMatcher<GameEntity> _matcherEffectViewPath;

    public static Entitas.IMatcher<GameEntity> EffectViewPath {
        get {
            if (_matcherEffectViewPath == null) {
                var matcher = (Entitas.Matcher<GameEntity>)Entitas.Matcher<GameEntity>.AllOf(GameComponentsLookup.EffectViewPath);
                matcher.componentNames = GameComponentsLookup.componentNames;
                _matcherEffectViewPath = matcher;
            }

            return _matcherEffectViewPath;
        }
    }
}
