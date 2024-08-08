//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Bogenbai.CustomGenerators.Plugins.CustomComponentEntityApiGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public partial class GameEntity {

    static readonly AbilityMadness.Code.Gameplay.Weapons.WeaponComponent weaponComponent = new AbilityMadness.Code.Gameplay.Weapons.WeaponComponent();

    public bool isWeapon {
        get { return HasComponent(GameComponentsLookup.Weapon); }
        set {
            if (value != isWeapon) {
                var index = GameComponentsLookup.Weapon;
                if (value) {
                    var componentPool = GetComponentPool(index);
                    var component = componentPool.Count > 0
                            ? componentPool.Pop()
                            : weaponComponent;

                    AddComponent(index, component);
                } else {
                    RemoveComponent(index);
                }
            }
        }
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

    static Entitas.IMatcher<GameEntity> _matcherWeapon;

    public static Entitas.IMatcher<GameEntity> Weapon {
        get {
            if (_matcherWeapon == null) {
                var matcher = (Entitas.Matcher<GameEntity>)Entitas.Matcher<GameEntity>.AllOf(GameComponentsLookup.Weapon);
                matcher.componentNames = GameComponentsLookup.componentNames;
                _matcherWeapon = matcher;
            }

            return _matcherWeapon;
        }
    }
}