using System.Collections.Generic;
using AbilityMadness.Code.Gameplay.Weapons.Bullets.Configs;

namespace AbilityMadness.Code.Gameplay.Weapons.Bullets.Services
{
    public interface IBulletService
    {
        List<BulletTypeId> Bullets { get; }
        BulletConfig[] GetBulletConfigs();
    }
}
