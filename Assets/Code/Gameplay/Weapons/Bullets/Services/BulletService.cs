using System.Collections.Generic;

namespace AbilityMadness.Code.Gameplay.Weapons.Bullets.Services
{
    public class BulletService : IBulletService
    {
        private const int BULLET_ALLOC_SIZE = 4;

        public List<BulletTypeId> Bullets { get; private set; } = new(BULLET_ALLOC_SIZE);
    }
}
