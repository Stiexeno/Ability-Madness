//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Bogenbai.CustomGenerators.Plugins.CustomComponentEntityApiGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public partial class GameEntity {

    private AbilityMadness.Code.Gameplay.Weapons.Bullets.BulletTypeIdComponent bulletTypeId { get { return (AbilityMadness.Code.Gameplay.Weapons.Bullets.BulletTypeIdComponent)GetComponent(GameComponentsLookup.BulletTypeId); } }
    public AbilityMadness.Code.Gameplay.Weapons.BulletTypeId BulletTypeId { get { return bulletTypeId.Value; } set { bulletTypeId.Value = value; }}
    public bool hasBulletTypeId { get { return HasComponent(GameComponentsLookup.BulletTypeId); } }

    public GameEntity AddBulletTypeId(AbilityMadness.Code.Gameplay.Weapons.BulletTypeId newValue) {
        var index = GameComponentsLookup.BulletTypeId;
        var component = (AbilityMadness.Code.Gameplay.Weapons.Bullets.BulletTypeIdComponent)CreateComponent(index, typeof(AbilityMadness.Code.Gameplay.Weapons.Bullets.BulletTypeIdComponent));
        component.Value = newValue;
        AddComponent(index, component);

        return this;
    }

    public GameEntity ReactiveReplaceBulletTypeId(AbilityMadness.Code.Gameplay.Weapons.BulletTypeId newValue) {
        var index = GameComponentsLookup.BulletTypeId;
        var component = (AbilityMadness.Code.Gameplay.Weapons.Bullets.BulletTypeIdComponent)CreateComponent(index, typeof(AbilityMadness.Code.Gameplay.Weapons.Bullets.BulletTypeIdComponent));
        component.Value = newValue;
        ReplaceComponent(index, component);

        return this;
    }

    public GameEntity ReplaceBulletTypeId(AbilityMadness.Code.Gameplay.Weapons.BulletTypeId newValue) {
        if (!hasBulletTypeId) 
        {
            AddBulletTypeId(newValue);
            return this;
        }

        bulletTypeId.Value = newValue;
        return this;
    }

    public GameEntity RemoveBulletTypeId() {
        RemoveComponent(GameComponentsLookup.BulletTypeId);
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

    static Entitas.IMatcher<GameEntity> _matcherBulletTypeId;

    public static Entitas.IMatcher<GameEntity> BulletTypeId {
        get {
            if (_matcherBulletTypeId == null) {
                var matcher = (Entitas.Matcher<GameEntity>)Entitas.Matcher<GameEntity>.AllOf(GameComponentsLookup.BulletTypeId);
                matcher.componentNames = GameComponentsLookup.componentNames;
                _matcherBulletTypeId = matcher;
            }

            return _matcherBulletTypeId;
        }
    }
}
