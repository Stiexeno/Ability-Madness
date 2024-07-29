using AbilityMadness.Code.Common;
using AbilityMadness.Code.Common.Collision;
using AbilityMadness.Code.Common.Destruct;
using AbilityMadness.Code.Gameplay.Animator;
using AbilityMadness.Code.Gameplay.Chest;
using AbilityMadness.Code.Gameplay.Input;
using AbilityMadness.Code.Gameplay.Interaction;
using AbilityMadness.Code.Gameplay.Movement;
using AbilityMadness.Code.Gameplay.Vitals;

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
            Add(systemFactory.Create<VitalsFeature>());

            Add(systemFactory.Create<CollisionFeature>());
            Add(systemFactory.Create<DestructFeature>());
        }
    }
}
