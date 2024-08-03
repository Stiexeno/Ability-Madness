using System.Collections.Generic;
using AbilityMadness.Code.Common;
using AbilityMadness.Code.Extensions;
using AbilityMadness.Code.Gameplay.Experience;
using AbilityMadness.Code.Gameplay.Health;
using AbilityMadness.Code.Infrastructure.Services.Identifiers;
using AbilityMadness.Infrastructure.Services.Assets;
using UnityEngine;

namespace AbilityMadness.Code.Gameplay.Enemy.Factory
{
    public class EnemyFactory : IEnemyFactory
    {
        private IIdentifierService _identifierService;
        private IAssets _assets;

        public EnemyFactory(IIdentifierService identifierService, IAssets assets)
        {
            _assets = assets;
            _identifierService = identifierService;
        }

        public GameEntity CreateRobot(Vector3 position)
        {
            return CreateEntity.Empty()
                .AddId(_identifierService.Next())
                .With(x => x.isEnemy = true)
                .AddViewPath(Constants.Prefabs.Enemies.Robot)
                .AddTeam(Team.Enemy)
                .With(x => x.isAlive = true)
                .AddHealth(40)
                .AddMaxHealth(40)

                .AddExperienceTypeId(ExperienceTypeId.Green)

                .AddTargetsInSight(new List<int>(1))

                .With(x => x.isTransformMovement = true)
                .With(x => x.isForwardMovement = true)
                .AddMovementSpeed(0.01f)
                .AddVelocity(Vector2.zero)
                .AddWorldPosition(position)
                .AddDirection(Vector2.zero)
                .AddLookDirection(Vector2.zero);
        }
    }
}
