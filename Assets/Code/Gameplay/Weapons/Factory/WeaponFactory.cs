using AbilityMadness.Code.Common;
using AbilityMadness.Code.Extensions;
using AbilityMadness.Code.Gameplay.Weapons.Bullets.Factory;
using AbilityMadness.Code.Infrastructure.Services.Identifiers;
using AbilityMadness.Infrastructure.Services.Configs;
using UnityEngine;
using Zenject;

namespace AbilityMadness.Code.Gameplay.Weapons.Factory
{
    public class WeaponFactory : IWeaponFactory
    {
        private const string WeaponPrefabPath = "Prefabs/Weapons/Weapon_Revolver";

        private IIdentifierService _identifierService;
        private IConfigsService _configsService;
        private IBulletFactory _bulletFactory;

        [Inject]
        private void Construct(
            IIdentifierService identifierService,
            IConfigsService configsService,
            IBulletFactory bulletFactory)
        {
            _bulletFactory = bulletFactory;
            _configsService = configsService;
            _identifierService = identifierService;
        }

        public GameEntity CreateWeapon(GameEntity gameEntity, WeaponTypeId weaponType)
        {
            var id = _identifierService.Next();
            var config = _configsService.GetWeaponConfig(weaponType);

            _bulletFactory.CreateBullets(id, config, gameEntity.Team);

            return CreateEntity.Empty()
                .AddId(id)
                .With(x => x.isWeapon = true)
                .AddWeaponTypeId(weaponType)
                .AddViewPath(WeaponPrefabPath)
                .AddOwnerId(gameEntity.Id)
                .AddTeam(gameEntity.Team)

                .With(x => x.isTransformMovement = true)
                .AddOffset(Vector3.up * 0.2f)
                .AddWorldPosition(Vector3.zero)
                .AddDirection(Vector2.zero)

                .AddReloadTime(config.reloadTime)
                .AddFireRate(config.fireRate)
                .AddAmmoCapacity(config.ammoCapacity)
                .AddMaxAmmoCapacity(config.ammoCapacity)
                .AddAmmoIndex(0);
        }
    }
}
