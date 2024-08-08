using AbilityMadness.Code.Gameplay.Weapons.Behaviours;
using Entitas;

namespace AbilityMadness.Code.Gameplay.Weapons
{
    [Game] public class WeaponComponent : IComponent {  }
    [Game] public class WeaponTypeIdComponent : IComponent { public WeaponTypeId Value; }

    [Game] public class Ready : IComponent {  }

    [Game] public class AmmoCapacity : IComponent { public int Value; }
    [Game] public class MaxAmmoCapacity : IComponent { public int Value; }
    [Game] public class AmmoIndex : IComponent { public int Value; }

    [Game] public class FireRate : IComponent { public float Value; }
    [Game] public class ReloadTime : IComponent { public float Value; }
    [Game] public class Reloading : IComponent {  }
    [Game] public class Recovering : IComponent {  }

    [Game] public class Shot : IComponent { }

    [Game] public class WeaponAnimatorComponent : IComponent { public WeaponAnimator Value; }
}
