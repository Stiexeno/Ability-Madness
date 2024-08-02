using AbilityMadness.Code.Gameplay.Health.Behaviours;
using AbilityMadness.Code.Infrastructure.View;
using SF = UnityEngine.SerializeField;

namespace AbilityMadness.Code.Gameplay.Health.Registrars
{
    [EntityTag("Registrars")]
    public class HealthbarRegistrar : EntityComponentRegistrar
    {
        [SF] private Healthbar healthbar;

        public override void RegisterComponents(GameEntity entity)
        {
            entity.AddHealthbar(healthbar);
        }

        public override void UnregisterComponents(GameEntity entity)
        {
            entity.RemoveHealthbar();
        }
    }
}
