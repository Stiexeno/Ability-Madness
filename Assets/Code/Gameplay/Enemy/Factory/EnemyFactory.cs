using System.Collections.Generic;
using AbilityMadness.Code.Common;
using AbilityMadness.Code.Extensions;
using AbilityMadness.Code.Gameplay.Experience;
using AbilityMadness.Code.Gameplay.Health;
using AbilityMadness.Code.Gameplay.Movement;
using AbilityMadness.Code.Gameplay.TargetCollection;
using AbilityMadness.Code.Gameplay.Vision;
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
                .AddHealth(30)
                .AddMaxHealth(30)
                .AddDamage(3)

                .AddExperienceTypeId(ExperienceTypeId.Green)
                .CollectTargetsWithSphereCast(0.3f)

                // .AddTargetsInSight(new List<int>(1))

                //.With(x => x.isTransformMovement = true)
                //.With(x => x.isForwardMovement = true)
                .SetRigidbodyMovement(1.5f)
                .AddWorldPosition(position)
                .AddLookDirection(Vector2.zero);
            //.AddDirection(Vector2.zero)
            // .SetVision(8f, 1f, Constants.Layers.Player);

        }
    }
}
