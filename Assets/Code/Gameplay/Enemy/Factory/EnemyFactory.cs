using System.Collections.Generic;
using AbilityMadness.Code.Common;
using AbilityMadness.Code.Extensions;
using AbilityMadness.Code.Gameplay.EffectApplication;
using AbilityMadness.Code.Gameplay.EffectApplication.Factory;
using AbilityMadness.Code.Gameplay.Experience;
using AbilityMadness.Code.Gameplay.Health;
using AbilityMadness.Code.Gameplay.Movement;
using AbilityMadness.Code.Gameplay.Stats;
using AbilityMadness.Code.Gameplay.TargetCollection;
using AbilityMadness.Code.Gameplay.Vision;
using AbilityMadness.Code.Infrastructure.Services.Identifiers;
using AbilityMadness.Infrastructure.Services.Assets;
using AbilityMadness.Infrastructure.Services.Configs;
using UnityEngine;

namespace AbilityMadness.Code.Gameplay.Enemy.Factory
{
    public class EnemyFactory : IEnemyFactory
    {
        private IIdentifierService _identifierService;
        private IAssets _assets;
        private IConfigsService _configsService;

        public EnemyFactory(IIdentifierService identifierService, IAssets assets, IConfigsService configsService)
        {
            _configsService = configsService;
            _assets = assets;
            _identifierService = identifierService;
        }

        public GameEntity CreateRobot(Vector3 position)
        {
            var enemyConfig = _configsService.GetEnemyConfig(EnemyTypeId.Robot);
            var baseStats = enemyConfig.baseStats;

            return CreateEntity.Empty()
                .AddId(_identifierService.Next())
                .With(x => x.isEnemy = true)
                .AddViewPath(Constants.Prefabs.Enemies.Robot)
                .AddTeam(Team.Enemy)
                .With(x => x.isAlive = true)
                .AddHealth(baseStats.maxHealth)
                .AddMaxHealth(baseStats.maxHealth)
                .AddEffectSetups(enemyConfig.effectSetups)
                .AddBaseStats(new StatsData(baseStats))
                .AddStatsModifiers(new StatsData())

                .AddExperienceTypeId(ExperienceTypeId.Green)
                .CollectTargetsWithSphereCast(0.3f)

                // .AddTargetsInSight(new List<int>(1))

                .SetRigidbodyMovement(baseStats.movementSpeed)
                .AddWorldPosition(position)
                .AddLookDirection(Vector2.zero);
            // .SetVision(8f, 1f, Constants.Layers.Player);

        }
    }
}
