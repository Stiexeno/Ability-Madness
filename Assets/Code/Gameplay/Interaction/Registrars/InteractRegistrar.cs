using AbilityMadness.Code.Gameplay.Interaction.Behaviours;
using AbilityMadness.Code.Infrastructure.View;
using SF = UnityEngine.SerializeField;

namespace AbilityMadness.Code.Gameplay.Interaction.Registrars
{
    public class InteractRegistrar : EntityComponentRegistrar
    {
        [SF] private InteractBehaviour interactBehaviour;

        public override void RegisterComponents(GameEntity entity)
        {
            entity.AddInteractBehaviour(interactBehaviour);
        }

        public override void UnregisterComponents(GameEntity entity)
        {
            if (entity.hasInteractBehaviour)
                entity.RemoveInteractBehaviour();
        }
    }
}
