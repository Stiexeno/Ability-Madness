//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Bogenbai.CustomGenerators.Plugins.CustomComponentEntityApiGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public partial class GameEntity {

    private AbilityMadness.Code.Gameplay.Weapons.Bullets.BulletIndex bulletIndex { get { return (AbilityMadness.Code.Gameplay.Weapons.Bullets.BulletIndex)GetComponent(GameComponentsLookup.BulletIndex); } }
    public int BulletIndex { get { return bulletIndex.Value; } set { bulletIndex.Value = value; }}
    public bool hasBulletIndex { get { return HasComponent(GameComponentsLookup.BulletIndex); } }

    public GameEntity AddBulletIndex(int newValue) {
        var index = GameComponentsLookup.BulletIndex;
        var component = (AbilityMadness.Code.Gameplay.Weapons.Bullets.BulletIndex)CreateComponent(index, typeof(AbilityMadness.Code.Gameplay.Weapons.Bullets.BulletIndex));
        component.Value = newValue;
        AddComponent(index, component);

        return this;
    }

    public GameEntity ReactiveReplaceBulletIndex(int newValue) {
        var index = GameComponentsLookup.BulletIndex;
        var component = (AbilityMadness.Code.Gameplay.Weapons.Bullets.BulletIndex)CreateComponent(index, typeof(AbilityMadness.Code.Gameplay.Weapons.Bullets.BulletIndex));
        component.Value = newValue;
        ReplaceComponent(index, component);

        return this;
    }

    public GameEntity ReplaceBulletIndex(int newValue) {
        if (!hasBulletIndex) 
        {
            AddBulletIndex(newValue);
            return this;
        }

        bulletIndex.Value = newValue;
        return this;
    }

    public GameEntity RemoveBulletIndex() {
        RemoveComponent(GameComponentsLookup.BulletIndex);
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

    static Entitas.IMatcher<GameEntity> _matcherBulletIndex;

    public static Entitas.IMatcher<GameEntity> BulletIndex {
        get {
            if (_matcherBulletIndex == null) {
                var matcher = (Entitas.Matcher<GameEntity>)Entitas.Matcher<GameEntity>.AllOf(GameComponentsLookup.BulletIndex);
                matcher.componentNames = GameComponentsLookup.componentNames;
                _matcherBulletIndex = matcher;
            }

            return _matcherBulletIndex;
        }
    }
}