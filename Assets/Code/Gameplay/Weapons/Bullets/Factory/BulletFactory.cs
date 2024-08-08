using System;
using AbilityMadness.Code.Common;
using AbilityMadness.Code.Extensions;
using AbilityMadness.Code.Gameplay.Health;
using AbilityMadness.Code.Gameplay.Weapons.Configs;
using AbilityMadness.Code.Infrastructure.Services.Identifiers;

namespace AbilityMadness.Code.Gameplay.Weapons.Bullets.Factory
{
    public class BulletFactory : IBulletFactory
    {
        private IIdentifierService _identifierService;

        public BulletFactory(IIdentifierService identifierService)
        {
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
                    return CreateRegularBullet(targetId, index, team);
                case BulletTypeId.Hard:
                    return CreateHardBullet(targetId, index, team);
                default:
                    throw new Exception($"Unknown bullet type: {type}");
            }
        }

        public GameEntity CreateRegularBullet(int targetId, int index, Team team)
        {
            return CreateEntity.Empty()
                .AddId(_identifierService.Next())
                .AddTargetId(targetId)

                .With(x => x.isBullet = true)
                .AddBulletTypeId(BulletTypeId.Regular)
                .AddTeam(team)
                .AddDamage(10)

                .AddBulletIndex(index);
        }

        private GameEntity CreateHardBullet(int targetId, int index, Team team)
        {
            return CreateEntity.Empty()
                .AddId(_identifierService.Next())
                .AddTargetId(targetId)

                .With(x => x.isBullet = true)
                .AddBulletTypeId(BulletTypeId.Hard)
                .AddTeam(team)
                .AddDamage(20)

                .AddBulletIndex(index);
        }

        public void CreateBullets(GameEntity gameEntity, WeaponConfig weaponConfig)
        {
            throw new NotImplementedException();
        }
    }
}
