using System.Collections.Generic;

namespace AbilityMadness.Code.Gameplay.Weapons.Bullets.Services
{
    public interface IBulletService
    {
        List<BulletTypeId> Bullets { get; }
    }
}
