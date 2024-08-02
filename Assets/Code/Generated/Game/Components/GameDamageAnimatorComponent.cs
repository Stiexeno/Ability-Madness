//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Bogenbai.CustomGenerators.Plugins.CustomComponentEntityApiGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public partial class GameEntity {

    private AbilityMadness.Code.Gameplay.Animator.DamageAnimatorComponent damageAnimator { get { return (AbilityMadness.Code.Gameplay.Animator.DamageAnimatorComponent)GetComponent(GameComponentsLookup.DamageAnimator); } }
    public AbilityMadness.Code.Common.Behaviours.DamageAnimator DamageAnimator { get { return damageAnimator.Value; } set { damageAnimator.Value = value; }}
    public bool hasDamageAnimator { get { return HasComponent(GameComponentsLookup.DamageAnimator); } }

    public GameEntity AddDamageAnimator(AbilityMadness.Code.Common.Behaviours.DamageAnimator newValue) {
        var index = GameComponentsLookup.DamageAnimator;
        var component = (AbilityMadness.Code.Gameplay.Animator.DamageAnimatorComponent)CreateComponent(index, typeof(AbilityMadness.Code.Gameplay.Animator.DamageAnimatorComponent));
        component.Value = newValue;
        AddComponent(index, component);

        return this;
    }

    public GameEntity ReactiveReplaceDamageAnimator(AbilityMadness.Code.Common.Behaviours.DamageAnimator newValue) {
        var index = GameComponentsLookup.DamageAnimator;
        var component = (AbilityMadness.Code.Gameplay.Animator.DamageAnimatorComponent)CreateComponent(index, typeof(AbilityMadness.Code.Gameplay.Animator.DamageAnimatorComponent));
        component.Value = newValue;
        ReplaceComponent(index, component);

        return this;
    }

    public GameEntity ReplaceDamageAnimator(AbilityMadness.Code.Common.Behaviours.DamageAnimator newValue) {
        if (!hasDamageAnimator) 
        {
            AddDamageAnimator(newValue);
            return this;
        }

        damageAnimator.Value = newValue;
        return this;
    }

    public GameEntity RemoveDamageAnimator() {
        RemoveComponent(GameComponentsLookup.DamageAnimator);
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

    static Entitas.IMatcher<GameEntity> _matcherDamageAnimator;

    public static Entitas.IMatcher<GameEntity> DamageAnimator {
        get {
            if (_matcherDamageAnimator == null) {
                var matcher = (Entitas.Matcher<GameEntity>)Entitas.Matcher<GameEntity>.AllOf(GameComponentsLookup.DamageAnimator);
                matcher.componentNames = GameComponentsLookup.componentNames;
                _matcherDamageAnimator = matcher;
            }

            return _matcherDamageAnimator;
        }
    }
}