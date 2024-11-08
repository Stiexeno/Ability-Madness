//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Bogenbai.CustomGenerators.Plugins.CustomComponentEntityApiGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public partial class GameEntity {

    private AbilityMadness.Code.Gameplay.Gears.GearTypeIdComponent gearTypeId { get { return (AbilityMadness.Code.Gameplay.Gears.GearTypeIdComponent)GetComponent(GameComponentsLookup.GearTypeId); } }
    public AbilityMadness.Code.Gameplay.Gears.GearTypeId GearTypeId { get { return gearTypeId.Value; } set { gearTypeId.Value = value; }}
    public bool hasGearTypeId { get { return HasComponent(GameComponentsLookup.GearTypeId); } }

    public GameEntity AddGearTypeId(AbilityMadness.Code.Gameplay.Gears.GearTypeId newValue) {
        var index = GameComponentsLookup.GearTypeId;
        var component = (AbilityMadness.Code.Gameplay.Gears.GearTypeIdComponent)CreateComponent(index, typeof(AbilityMadness.Code.Gameplay.Gears.GearTypeIdComponent));
        component.Value = newValue;
        AddComponent(index, component);

        return this;
    }

    public GameEntity ReactiveReplaceGearTypeId(AbilityMadness.Code.Gameplay.Gears.GearTypeId newValue) {
        var index = GameComponentsLookup.GearTypeId;
        var component = (AbilityMadness.Code.Gameplay.Gears.GearTypeIdComponent)CreateComponent(index, typeof(AbilityMadness.Code.Gameplay.Gears.GearTypeIdComponent));
        component.Value = newValue;
        ReplaceComponent(index, component);

        return this;
    }

    public GameEntity ReplaceGearTypeId(AbilityMadness.Code.Gameplay.Gears.GearTypeId newValue) {
        if (!hasGearTypeId) 
        {
            AddGearTypeId(newValue);
            return this;
        }

        gearTypeId.Value = newValue;
        return this;
    }

    public GameEntity RemoveGearTypeId() {
        RemoveComponent(GameComponentsLookup.GearTypeId);
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

    static Entitas.IMatcher<GameEntity> _matcherGearTypeId;

    public static Entitas.IMatcher<GameEntity> GearTypeId {
        get {
            if (_matcherGearTypeId == null) {
                var matcher = (Entitas.Matcher<GameEntity>)Entitas.Matcher<GameEntity>.AllOf(GameComponentsLookup.GearTypeId);
                matcher.componentNames = GameComponentsLookup.componentNames;
                _matcherGearTypeId = matcher;
            }

            return _matcherGearTypeId;
        }
    }
}
