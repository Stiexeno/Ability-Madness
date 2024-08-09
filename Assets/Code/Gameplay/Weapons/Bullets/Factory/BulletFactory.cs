using System;
using AbilityMadness.Code.Common;
using AbilityMadness.Code.Extensions;
using AbilityMadness.Code.Gameplay.Health;
using AbilityMadness.Code.Gameplay.Weapons.Configs;
using AbilityMadness.Code.Infrastructure.Services.Identifiers;
using AbilityMadness.Infrastructure.Services.Configs;

namespace AbilityMadness.Code.Gameplay.Weapons.Bullets.Factory
{
    public class BulletFactory : IBulletFactory
    {
        private IIdentifierService _identifierService;
        private IConfigsService _configsService;

        public BulletFactory(IIdentifierService identifierService, IConfigsService configsService)
        {
            _configsService = configsService;
            _identifierService = identifierService;
        }

        public void CreateBullets(int targetId, WeaponConfig weaponConfig, Team team)
        {
            for (int i = 0; i < weaponConfig.bullets.Length; i++)
            {
                var bullet = weaponConfig.bullets[i];

                CreateBullet(targetId, bullet.type, i, team);
            }
        }

        public GameEntity CreateBullet(int targetId, BulletTypeId type, int index, Team team)
        {
            switch (type)
            {
                case BulletTypeId.Unkonwn:
                    throw new ArgumentOutOfRangeException(nameof(type), type, null);
                case BulletTypeId.Regular:
                    return CreateRegularBullet(type, targetId, index, team);
                case BulletTypeId.Hard:
                    return CreateHardBullet(type, targetId, index, team);
                case BulletTypeId.Ricochet:
                    return CreateRicochetBullet(type, targetId, index, team);
                default:
                    throw new Exception($"Unknown bullet type: {type}");
            }
        }

        public GameEntity CreateRegularBullet(BulletTypeId type, int targetId, int index, Team team)
        {
            return CreateEmptyBullet(type, targetId, index, team);
        }

        private GameEntity CreateHardBullet(BulletTypeId type, int targetId, int index, Team team)
        {
            return CreateEmptyBullet(type, targetId, index, team);
        }

        private GameEntity CreateRicochetBullet(BulletTypeId type, int targetId, int index, Team team)
        {
            return CreateEmptyBullet(type, targetId, index, team);
        }

        private GameEntity CreateEmptyBullet(BulletTypeId bulletTypeId, int targetId, int index, Team team)
        {
            var config = _configsService.GetBulletConfig(bulletTypeId);

            return CreateEntity.Empty()
                .AddId(_identifierService.Next())
                .AddTargetId(targetId)

                .With(x => x.isBullet = true)
                .AddBulletTypeId(bulletTypeId)
                .AddTeam(team)
                .AddDamage(config.damage)
                .AddPierce(config.pierce)
                .AddMovementSpeed(config.movementSpeed)

                .AddBulletIndex(index);
        }
    }
}
