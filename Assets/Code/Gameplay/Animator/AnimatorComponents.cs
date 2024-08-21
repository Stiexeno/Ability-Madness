using AbilityMadness.Code.Common.Behaviours;
using Entitas;

namespace AbilityMadness.Code.Gameplay.Animator
{
    [Game] public class MovementAnimatorComponent : IComponent { public MovementAnimator Value; }
    [Game] public class DamageAnimatorComponent : IComponent { public DamageAnimator Value; }
    [Game] public class DeathAnimatorComponent : IComponent { public DeathAnimator Value; }
}
