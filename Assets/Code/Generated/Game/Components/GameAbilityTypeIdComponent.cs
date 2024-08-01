//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Bogenbai.CustomGenerators.Plugins.CustomComponentEntityApiGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public partial class GameEntity {

    private AbilityMadness.Code.Gameplay.Abilities.AbilityTypeIdComponent abilityTypeId { get { return (AbilityMadness.Code.Gameplay.Abilities.AbilityTypeIdComponent)GetComponent(GameComponentsLookup.AbilityTypeId); } }
    public AbilityMadness.Code.Gameplay.Abilities.AbilityTypeId AbilityTypeId { get { return abilityTypeId.Value; } set { abilityTypeId.Value = value; }}
    public bool hasAbilityTypeId { get { return HasComponent(GameComponentsLookup.AbilityTypeId); } }

    public GameEntity AddAbilityTypeId(AbilityMadness.Code.Gameplay.Abilities.AbilityTypeId newValue) {
        var index = GameComponentsLookup.AbilityTypeId;
        var component = (AbilityMadness.Code.Gameplay.Abilities.AbilityTypeIdComponent)CreateComponent(index, typeof(AbilityMadness.Code.Gameplay.Abilities.AbilityTypeIdComponent));
        component.Value = newValue;
        AddComponent(index, component);

        return this;
    }

    public GameEntity ReactiveReplaceAbilityTypeId(AbilityMadness.Code.Gameplay.Abilities.AbilityTypeId newValue) {
        var index = GameComponentsLookup.AbilityTypeId;
        var component = (AbilityMadness.Code.Gameplay.Abilities.AbilityTypeIdComponent)CreateComponent(index, typeof(AbilityMadness.Code.Gameplay.Abilities.AbilityTypeIdComponent));
        component.Value = newValue;
        ReplaceComponent(index, component);

        return this;
    }

    public GameEntity ReplaceAbilityTypeId(AbilityMadness.Code.Gameplay.Abilities.AbilityTypeId newValue) {
        if (!hasAbilityTypeId) 
        {
            AddAbilityTypeId(newValue);
            return this;
        }

        abilityTypeId.Value = newValue;
        return this;
    }

    public GameEntity RemoveAbilityTypeId() {
        RemoveComponent(GameComponentsLookup.AbilityTypeId);
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

    static Entitas.IMatcher<GameEntity> _matcherAbilityTypeId;

    public static Entitas.IMatcher<GameEntity> AbilityTypeId {
        get {
            if (_matcherAbilityTypeId == null) {
                var matcher = (Entitas.Matcher<GameEntity>)Entitas.Matcher<GameEntity>.AllOf(GameComponentsLookup.AbilityTypeId);
                matcher.componentNames = GameComponentsLookup.componentNames;
                _matcherAbilityTypeId = matcher;
            }

            return _matcherAbilityTypeId;
        }
    }
}
