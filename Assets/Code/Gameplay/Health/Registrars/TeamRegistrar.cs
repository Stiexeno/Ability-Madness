using AbilityMadness.Code.Infrastructure.View;
using SF = UnityEngine.SerializeField;

namespace AbilityMadness.Code.Gameplay.Health.Registrars
{
    public class TeamRegistrar : EntityComponentRegistrar
    {
        [SF] private Team team;

        public override void RegisterComponents(GameEntity entity)
        {
            entity.AddTeam(team);
        }

        public override void UnregisterComponents(GameEntity entity)
        {
            entity.RemoveTeam();
        }
    }
}
