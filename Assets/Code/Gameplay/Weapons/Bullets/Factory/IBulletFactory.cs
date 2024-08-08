using AbilityMadness.Code.Gameplay.Health;
using AbilityMadness.Code.Gameplay.Weapons.Configs;

namespace AbilityMadness.Code.Gameplay.Weapons.Bullets.Factory
{
    public interface IBulletFactory
    {
        void CreateBullets(int targetId, WeaponConfig weaponConfig, Team team);
    }
}
