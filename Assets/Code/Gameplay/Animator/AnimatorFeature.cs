using AbilityMadness.Code.Gameplay.Animator.Systems;
using AbilityMadness.Code.Infrastructure.Services.ECS;

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
