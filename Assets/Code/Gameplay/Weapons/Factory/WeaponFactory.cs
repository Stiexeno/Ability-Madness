using AbilityMadness.Code.Common;
using AbilityMadness.Code.Extensions;
using AbilityMadness.Code.Infrastructure.Services.Identifiers;
using UnityEngine;
using Zenject;

namespace AbilityMadness.Code.Gameplay.Weapons.Factory
{
    public class WeaponFactory : IWeaponFactory
    {
        private const string WeaponPrefabPath = "Prefabs/Weapons/Weapon_Revolver";

        private IIdentifierService _identifierService;

        [Inject]
        private void Construct(IIdentifierService identifierService)
        {
            _identifierService = identifierService;
        }

        public GameEntity CreateWeapon(GameEntity gameEntity)
        {
            return CreateEntity.Empty()
                .AddId(_identifierService.Next())
                .With(x => x.isWeapon = true)
                .AddViewPath(WeaponPrefabPath)
                .AddOwnerId(gameEntity.Id)

                .With(x => x.isTransformMovement = true)
                .AddOffset(Vector3.up * 0.2f)
                .AddWorldPosition(Vector3.zero)
                .AddDirection(Vector2.zero);
        }
    }
}
