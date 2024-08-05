using AbilityMadness.Code.Gameplay.Weapons.Behaviours;
using Entitas;

namespace AbilityMadness.Code.Gameplay.Weapons
{
    [Game] public class WeaponComponent : IComponent {  }

    [Game] public class WeaponAnimatorComponent : IComponent { public WeaponAnimator Value; }
}
