using System.Collections.Generic;
using AbilityMadness.Code.Gameplay.Weapons.Bullets.Configs;
using AbilityMadness.Code.Gameplay.Weapons.Bullets.Factory;
using AbilityMadness.Code.Infrastructure.Configs;

namespace AbilityMadness.Code.Gameplay.Weapons.Bullets.Services
{
    public class BulletService : IBulletService
    {
        private IConfigsService _configsService;
        private IBulletFactory _bulletFactory;

        private const int BULLET_ALLOC_SIZE = 4;

        public List<BulletTypeId> Bullets { get; private set; } = new(BULLET_ALLOC_SIZE);

        public BulletService(IConfigsService configsService, IBulletFactory bulletFactory)
        {
            _bulletFactory = bulletFactory;
            _configsService = configsService;
        }

        public void ChangeTo(BulletTypeId type, int index)
        {
            _bulletFactory.CreateBulletRequest(type, index);
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
