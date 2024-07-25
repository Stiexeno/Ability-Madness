using AbilityMadness.Code.Common;
using AbilityMadness.Code.Gameplay;
using AbilityMadness.Code.Gameplay.Camera;
using AbilityMadness.Code.Gameplay.Input;
using AbilityMadness.Code.Gameplay.Movement;

namespace AbilityMadness.Code.Infrastructure.Services.ECS
{
    public class BattleUpdateFeature : Feature
    {
        public BattleUpdateFeature(ISystemFactory systemFactory)
        {
            Add(systemFactory.Create<InputFeature>());
            Add(systemFactory.Create<ViewFeature>());
            Add(systemFactory.Create<PlayerFeature>());
            Add(systemFactory.Create<MovementUpdateFeature>());
            Add(systemFactory.Create<CameraFreature>());
            Add(systemFactory.Create<CommonFeature>());

            Add(systemFactory.Create<CleanupDestructedSystem>());
        }
    }
}
