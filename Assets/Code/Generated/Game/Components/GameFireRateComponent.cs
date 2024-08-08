//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Bogenbai.CustomGenerators.Plugins.CustomComponentEntityApiGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public partial class GameEntity {

    private AbilityMadness.Code.Gameplay.Weapons.FireRate fireRate { get { return (AbilityMadness.Code.Gameplay.Weapons.FireRate)GetComponent(GameComponentsLookup.FireRate); } }
    public float FireRate { get { return fireRate.Value; } set { fireRate.Value = value; }}
    public bool hasFireRate { get { return HasComponent(GameComponentsLookup.FireRate); } }

    public GameEntity AddFireRate(float newValue) {
        var index = GameComponentsLookup.FireRate;
        var component = (AbilityMadness.Code.Gameplay.Weapons.FireRate)CreateComponent(index, typeof(AbilityMadness.Code.Gameplay.Weapons.FireRate));
        component.Value = newValue;
        AddComponent(index, component);

        return this;
    }

    public GameEntity ReactiveReplaceFireRate(float newValue) {
        var index = GameComponentsLookup.FireRate;
        var component = (AbilityMadness.Code.Gameplay.Weapons.FireRate)CreateComponent(index, typeof(AbilityMadness.Code.Gameplay.Weapons.FireRate));
        component.Value = newValue;
        ReplaceComponent(index, component);

        return this;
    }

    public GameEntity ReplaceFireRate(float newValue) {
        if (!hasFireRate) 
        {
            AddFireRate(newValue);
            return this;
        }

        fireRate.Value = newValue;
        return this;
    }

    public GameEntity RemoveFireRate() {
        RemoveComponent(GameComponentsLookup.FireRate);
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

    static Entitas.IMatcher<GameEntity> _matcherFireRate;

    public static Entitas.IMatcher<GameEntity> FireRate {
        get {
            if (_matcherFireRate == null) {
                var matcher = (Entitas.Matcher<GameEntity>)Entitas.Matcher<GameEntity>.AllOf(GameComponentsLookup.FireRate);
                matcher.componentNames = GameComponentsLookup.componentNames;
                _matcherFireRate = matcher;
            }

            return _matcherFireRate;
        }
    }
}
