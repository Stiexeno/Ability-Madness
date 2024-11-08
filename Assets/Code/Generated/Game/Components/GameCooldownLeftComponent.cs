//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Bogenbai.CustomGenerators.Plugins.CustomComponentEntityApiGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public partial class GameEntity {

    private AbilityMadness.Code.Common.Cooldown.CooldownLeft cooldownLeft { get { return (AbilityMadness.Code.Common.Cooldown.CooldownLeft)GetComponent(GameComponentsLookup.CooldownLeft); } }
    public float CooldownLeft { get { return cooldownLeft.Value; } set { cooldownLeft.Value = value; }}
    public bool hasCooldownLeft { get { return HasComponent(GameComponentsLookup.CooldownLeft); } }

    public GameEntity AddCooldownLeft(float newValue) {
        var index = GameComponentsLookup.CooldownLeft;
        var component = (AbilityMadness.Code.Common.Cooldown.CooldownLeft)CreateComponent(index, typeof(AbilityMadness.Code.Common.Cooldown.CooldownLeft));
        component.Value = newValue;
        AddComponent(index, component);

        return this;
    }

    public GameEntity ReactiveReplaceCooldownLeft(float newValue) {
        var index = GameComponentsLookup.CooldownLeft;
        var component = (AbilityMadness.Code.Common.Cooldown.CooldownLeft)CreateComponent(index, typeof(AbilityMadness.Code.Common.Cooldown.CooldownLeft));
        component.Value = newValue;
        ReplaceComponent(index, component);

        return this;
    }

    public GameEntity ReplaceCooldownLeft(float newValue) {
        if (!hasCooldownLeft) 
        {
            AddCooldownLeft(newValue);
            return this;
        }

        cooldownLeft.Value = newValue;
        return this;
    }

    public GameEntity RemoveCooldownLeft() {
        RemoveComponent(GameComponentsLookup.CooldownLeft);
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

    static Entitas.IMatcher<GameEntity> _matcherCooldownLeft;

    public static Entitas.IMatcher<GameEntity> CooldownLeft {
        get {
            if (_matcherCooldownLeft == null) {
                var matcher = (Entitas.Matcher<GameEntity>)Entitas.Matcher<GameEntity>.AllOf(GameComponentsLookup.CooldownLeft);
                matcher.componentNames = GameComponentsLookup.componentNames;
                _matcherCooldownLeft = matcher;
            }

            return _matcherCooldownLeft;
        }
    }
}
