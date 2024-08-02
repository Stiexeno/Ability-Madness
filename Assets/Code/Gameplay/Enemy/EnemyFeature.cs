using AbilityMadness.Code.Gameplay.Enemy.Systems;
using AbilityMadness.Code.Infrastructure.Services.ECS;

namespace AbilityMadness.Code.Gameplay.Enemy
{
    public class EnemyFeature : Feature
    {
        public EnemyFeature(ISystemFactory systemFactory)
        {
            Add(systemFactory.Create<SetEnemyTargetPlayerSystem>());
            Add(systemFactory.Create<MoveEnemyToTargetSystem>());
        }
    }
}
