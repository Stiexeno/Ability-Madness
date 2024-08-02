using AbilityMadness.Code.Infrastructure.View;
using SF = UnityEngine.SerializeField;

namespace AbilityMadness.Code.Gameplay.Health.Registrars
{
    [EntityTag("Registrars")]
    public class HealthRegistrar : EntityComponentRegistrar
    {
        [SF] private int health;

        public override void RegisterComponents(GameEntity entity)
        {
            entity.AddHealth(health);
        }

        public override void UnregisterComponents(GameEntity entity)
        {
            entity.RemoveHealth();
        }
    }
}
