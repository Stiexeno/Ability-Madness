using AbilityMadness.Code.Common;
using AbilityMadness.Code.Extensions;
using AbilityMadness.Code.Gameplay.Health;
using AbilityMadness.Code.Gameplay.Weapons.Configs;
using AbilityMadness.Code.Infrastructure.Assets;
using AbilityMadness.Code.Infrastructure.Configs;
using AbilityMadness.Code.Infrastructure.Identifiers;
using Cysharp.Threading.Tasks;
using UnityEngine;

namespace AbilityMadness.Code.Gameplay.Weapons.Bullets.Factory
{
    public class BulletFactory : IBulletFactory
    {
        private IIdentifierService _identifierService;
        private IConfigsService _configsService;
        private IAssets _assets;

        public BulletFactory(IIdentifierService identifierService, IConfigsService configsService, IAssets assets)
        {
            _assets = assets;
            _configsService = configsService;
            _identifierService = identifierService;
        }

        public void CreateBullets(int targetId, WeaponConfig weaponConfig, Team team)
        {
            for (int i = 0; i < weaponConfig.bullets.Length; i++)
            {
                var bullet = weaponConfig.bullets[i];

                CreateBullet(bullet.type, targetId, i, team);
            }
        }

        public GameEntity CreateBulletRequest(BulletTypeId type, int index)
        {
            return CreateEntity.Empty()
                .With(x => x.isBulletChangeRequest = true)
                .AddBulletTypeId(type)
                .AddBulletIndex(index);
        }

        public GameEntity CreateBullet(BulletTypeId type, int targetId, int index, Team team)
        {
            return type switch
            {
                _ => CreateDefaultBullet(type, targetId, index, team)
            };
        }

        public GameEntity CreateDefaultBullet(BulletTypeId type, int targetId, int index, Team team)
        {
            return CreateEmptyBullet(type, targetId, index, team);
        }

        private GameEntity CreateEmptyBullet(BulletTypeId bulletTypeId, int targetId, int index, Team team)
        {
            var config = _configsService.GetBulletConfig(bulletTypeId);
            _assets.LoadAsync<GameObject>(config.projectileRef).Forget();

            var bullet =  CreateEntity.Empty()
                .AddId(_identifierService.Next())
                .AddTargetId(targetId)
                .AddAssetReference(config.projectileRef)

                .With(x => x.isBullet = true)
                .AddBulletTypeId(bulletTypeId)
                .AddProjectileTypeId(config.projectileType)
                .AddTeam(team)

                .AddSpawnAmount(config.spawnCount)
                .AddBulletIndex(index);

            return bullet;
        }
    }
}
