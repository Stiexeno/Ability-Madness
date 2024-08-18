//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Bogenbai.CustomGenerators.Plugins.CustomComponentEntityApiGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public partial class GameEntity {

    static readonly AbilityMadness.Code.Gameplay.Weapons.Bullets.BulletChangeRequest bulletChangeRequestComponent = new AbilityMadness.Code.Gameplay.Weapons.Bullets.BulletChangeRequest();

    public bool isBulletChangeRequest {
        get { return HasComponent(GameComponentsLookup.BulletChangeRequest); }
        set {
            if (value != isBulletChangeRequest) {
                var index = GameComponentsLookup.BulletChangeRequest;
                if (value) {
                    var componentPool = GetComponentPool(index);
                    var component = componentPool.Count > 0
                            ? componentPool.Pop()
                            : bulletChangeRequestComponent;

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

    static Entitas.IMatcher<GameEntity> _matcherBulletChangeRequest;

    public static Entitas.IMatcher<GameEntity> BulletChangeRequest {
        get {
            if (_matcherBulletChangeRequest == null) {
                var matcher = (Entitas.Matcher<GameEntity>)Entitas.Matcher<GameEntity>.AllOf(GameComponentsLookup.BulletChangeRequest);
                matcher.componentNames = GameComponentsLookup.componentNames;
                _matcherBulletChangeRequest = matcher;
            }

            return _matcherBulletChangeRequest;
        }
    }
}