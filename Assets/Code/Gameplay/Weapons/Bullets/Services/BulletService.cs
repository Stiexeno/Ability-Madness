using System.Collections.Generic;
using AbilityMadness.Code.Gameplay.Weapons.Bullets.Configs;
using AbilityMadness.Infrastructure.Services.Configs;

namespace AbilityMadness.Code.Gameplay.Weapons.Bullets.Services
{
    public class BulletService : IBulletService
    {
        private IConfigsService _configsService;
        private const int BULLET_ALLOC_SIZE = 4;

        public List<BulletTypeId> Bullets { get; private set; } = new(BULLET_ALLOC_SIZE);

        public BulletService(IConfigsService configsService)
        {
            _configsService = configsService;
        }

        public BulletConfig[] GetBulletConfigs()
        {
            var bulletConfigs = new BulletConfig[Bullets.Count];

            for (int i = 0; i < Bullets.Count; i++)
            {
                bulletConfigs[i] = _configsService.GetBulletConfig(Bullets[i]);
            }

            return bulletConfigs;
        }
    }
}
