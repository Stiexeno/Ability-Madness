using AbilityMadness.Code.Gameplay.Animator.Systems;
using AbilityMadness.Code.Infrastructure.ECS;

namespace AbilityMadness.Code.Gameplay.Animator
{
    public class AnimatorFeature : Feature
    {
        public AnimatorFeature(ISystemFactory systemFactory)
        {
            Add(systemFactory.Create<AnimateMovementSystem>());
        }
    }
}
