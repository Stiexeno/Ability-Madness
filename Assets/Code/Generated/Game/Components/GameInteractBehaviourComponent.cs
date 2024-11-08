//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Bogenbai.CustomGenerators.Plugins.CustomComponentEntityApiGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public partial class GameEntity {

    private AbilityMadness.Code.Gameplay.Interaction.InteractBehaviourComponent interactBehaviour { get { return (AbilityMadness.Code.Gameplay.Interaction.InteractBehaviourComponent)GetComponent(GameComponentsLookup.InteractBehaviour); } }
    public AbilityMadness.Code.Gameplay.Interaction.Behaviours.InteractBehaviour InteractBehaviour { get { return interactBehaviour.Value; } set { interactBehaviour.Value = value; }}
    public bool hasInteractBehaviour { get { return HasComponent(GameComponentsLookup.InteractBehaviour); } }

    public GameEntity AddInteractBehaviour(AbilityMadness.Code.Gameplay.Interaction.Behaviours.InteractBehaviour newValue) {
        var index = GameComponentsLookup.InteractBehaviour;
        var component = (AbilityMadness.Code.Gameplay.Interaction.InteractBehaviourComponent)CreateComponent(index, typeof(AbilityMadness.Code.Gameplay.Interaction.InteractBehaviourComponent));
        component.Value = newValue;
        AddComponent(index, component);

        return this;
    }

    public GameEntity ReactiveReplaceInteractBehaviour(AbilityMadness.Code.Gameplay.Interaction.Behaviours.InteractBehaviour newValue) {
        var index = GameComponentsLookup.InteractBehaviour;
        var component = (AbilityMadness.Code.Gameplay.Interaction.InteractBehaviourComponent)CreateComponent(index, typeof(AbilityMadness.Code.Gameplay.Interaction.InteractBehaviourComponent));
        component.Value = newValue;
        ReplaceComponent(index, component);

        return this;
    }

    public GameEntity ReplaceInteractBehaviour(AbilityMadness.Code.Gameplay.Interaction.Behaviours.InteractBehaviour newValue) {
        if (!hasInteractBehaviour) 
        {
            AddInteractBehaviour(newValue);
            return this;
        }

        interactBehaviour.Value = newValue;
        return this;
    }

    public GameEntity RemoveInteractBehaviour() {
        RemoveComponent(GameComponentsLookup.InteractBehaviour);
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

    static Entitas.IMatcher<GameEntity> _matcherInteractBehaviour;

    public static Entitas.IMatcher<GameEntity> InteractBehaviour {
        get {
            if (_matcherInteractBehaviour == null) {
                var matcher = (Entitas.Matcher<GameEntity>)Entitas.Matcher<GameEntity>.AllOf(GameComponentsLookup.InteractBehaviour);
                matcher.componentNames = GameComponentsLookup.componentNames;
                _matcherInteractBehaviour = matcher;
            }

            return _matcherInteractBehaviour;
        }
    }
}
