using AbilityMadness.Code.Gameplay.Weapons.Behaviours;
using AbilityMadness.Code.Infrastructure.View;
using SF = UnityEngine.SerializeField;

namespace AbilityMadness.Code.Gameplay.Weapons.Registrars
{
    [EntityTag("Registrars")]
    public class ReloadWidgetRegistrar : EntityComponentRegistrar
    {
        [SF] private ReloadWidget reloadWidget;

        public override void RegisterComponents(GameEntity entity)
        {
            entity.AddReloadWidget(reloadWidget);
        }

        public override void UnregisterComponents(GameEntity entity)
        {
            entity.RemoveReloadWidget();
        }
    }
}
