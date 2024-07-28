using AbilityMadness.Code.Common;
using AbilityMadness.Code.Gameplay;
using AbilityMadness.Code.Gameplay.Animator;
using AbilityMadness.Code.Gameplay.Chest;
using AbilityMadness.Code.Gameplay.Collision.Systems;
using AbilityMadness.Code.Gameplay.Input;
using AbilityMadness.Code.Gameplay.Interaction;
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
            Add(systemFactory.Create<CommonFeature>());
            Add(systemFactory.Create<AnimatorFeature>());
            Add(systemFactory.Create<InteractionFeature>());
            Add(systemFactory.Create<ChestFreature>());

            Add(systemFactory.Create<CleanupCollisionSystem>());
            Add(systemFactory.Create<CleanupDestructedSystem>());
        }
    }
}
