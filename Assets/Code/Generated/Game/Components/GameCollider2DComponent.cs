//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Bogenbai.CustomGenerators.Plugins.CustomComponentEntityApiGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public partial class GameEntity {

    private AbilityMadness.Code.Common.Collider2DComponent collider2D { get { return (AbilityMadness.Code.Common.Collider2DComponent)GetComponent(GameComponentsLookup.Collider2D); } }
    public UnityEngine.Collider2D Collider2D { get { return collider2D.Value; } set { collider2D.Value = value; }}
    public bool hasCollider2D { get { return HasComponent(GameComponentsLookup.Collider2D); } }

    public GameEntity AddCollider2D(UnityEngine.Collider2D newValue) {
        var index = GameComponentsLookup.Collider2D;
        var component = (AbilityMadness.Code.Common.Collider2DComponent)CreateComponent(index, typeof(AbilityMadness.Code.Common.Collider2DComponent));
        component.Value = newValue;
        AddComponent(index, component);

        return this;
    }

    public GameEntity ReactiveReplaceCollider2D(UnityEngine.Collider2D newValue) {
        var index = GameComponentsLookup.Collider2D;
        var component = (AbilityMadness.Code.Common.Collider2DComponent)CreateComponent(index, typeof(AbilityMadness.Code.Common.Collider2DComponent));
        component.Value = newValue;
        ReplaceComponent(index, component);

        return this;
    }

    public GameEntity ReplaceCollider2D(UnityEngine.Collider2D newValue) {
        if (!hasCollider2D) 
        {
            AddCollider2D(newValue);
            return this;
        }

        collider2D.Value = newValue;
        return this;
    }

    public GameEntity RemoveCollider2D() {
        RemoveComponent(GameComponentsLookup.Collider2D);
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

    static Entitas.IMatcher<GameEntity> _matcherCollider2D;

    public static Entitas.IMatcher<GameEntity> Collider2D {
        get {
            if (_matcherCollider2D == null) {
                var matcher = (Entitas.Matcher<GameEntity>)Entitas.Matcher<GameEntity>.AllOf(GameComponentsLookup.Collider2D);
                matcher.componentNames = GameComponentsLookup.componentNames;
                _matcherCollider2D = matcher;
            }

            return _matcherCollider2D;
        }
    }
}
