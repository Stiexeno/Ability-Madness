using Entitas;

namespace AbilityMadness.Code.Gameplay.Weapons.Bullets
{
    [Game] public class Bullet : IComponent { }
    [Game] public class BulletTypeIdComponent : IComponent { public BulletTypeId Value; }

    [Game] public class BulletIndex : IComponent { public int Value; }

    [Game] public class BulletChangeRequest : IComponent {  }
}
