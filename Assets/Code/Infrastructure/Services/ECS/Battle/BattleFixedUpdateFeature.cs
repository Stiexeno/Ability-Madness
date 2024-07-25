using AbilityMadness.Code.Gameplay.Movement;

namespace AbilityMadness.Code.Infrastructure.Services.ECS
{
    public class BattleFixedUpdateFeature : Feature
    {
        public BattleFixedUpdateFeature(ISystemFactory systemFactory)
        {
            Add(systemFactory.Create<MovementFixedUpdateFeature>());
        }
    }
}
