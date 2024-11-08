//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Bogenbai.CustomGenerators.Plugins.CustomComponentEntityApiGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public partial class GameEntity {

    private AbilityMadness.Code.Gameplay.Projectile.Throwable.MaxHeight maxHeight { get { return (AbilityMadness.Code.Gameplay.Projectile.Throwable.MaxHeight)GetComponent(GameComponentsLookup.MaxHeight); } }
    public float MaxHeight { get { return maxHeight.Value; } set { maxHeight.Value = value; }}
    public bool hasMaxHeight { get { return HasComponent(GameComponentsLookup.MaxHeight); } }

    public GameEntity AddMaxHeight(float newValue) {
        var index = GameComponentsLookup.MaxHeight;
        var component = (AbilityMadness.Code.Gameplay.Projectile.Throwable.MaxHeight)CreateComponent(index, typeof(AbilityMadness.Code.Gameplay.Projectile.Throwable.MaxHeight));
        component.Value = newValue;
        AddComponent(index, component);

        return this;
    }

    public GameEntity ReactiveReplaceMaxHeight(float newValue) {
        var index = GameComponentsLookup.MaxHeight;
        var component = (AbilityMadness.Code.Gameplay.Projectile.Throwable.MaxHeight)CreateComponent(index, typeof(AbilityMadness.Code.Gameplay.Projectile.Throwable.MaxHeight));
        component.Value = newValue;
        ReplaceComponent(index, component);

        return this;
    }

    public GameEntity ReplaceMaxHeight(float newValue) {
        if (!hasMaxHeight) 
        {
            AddMaxHeight(newValue);
            return this;
        }

        maxHeight.Value = newValue;
        return this;
    }

    public GameEntity RemoveMaxHeight() {
        RemoveComponent(GameComponentsLookup.MaxHeight);
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

    static Entitas.IMatcher<GameEntity> _matcherMaxHeight;

    public static Entitas.IMatcher<GameEntity> MaxHeight {
        get {
            if (_matcherMaxHeight == null) {
                var matcher = (Entitas.Matcher<GameEntity>)Entitas.Matcher<GameEntity>.AllOf(GameComponentsLookup.MaxHeight);
                matcher.componentNames = GameComponentsLookup.componentNames;
                _matcherMaxHeight = matcher;
            }

            return _matcherMaxHeight;
        }
    }
}
