using AbilityMadness.Code.Common;
using AbilityMadness.Code.Extensions;
using AbilityMadness.Code.Gameplay.Experience.Services;
using AbilityMadness.Code.Gameplay.Health;
using AbilityMadness.Code.Gameplay.Movement;
using AbilityMadness.Code.Gameplay.Stats;
using AbilityMadness.Code.Gameplay.Vision;
using AbilityMadness.Code.Infrastructure.Assets;
using AbilityMadness.Code.Infrastructure.Identifiers;
using UnityEngine;

namespace AbilityMadness.Factory
{
    public class PlayerFactory : IPlayerFactory
    {
        private const string PLAYER_PATH = "Character_Player";

        private IIdentifierService _identifierService;
        private IAssets _assets;
        private IExperienceCalculatorService _experienceCalculatorService;

        public PlayerFactory(IIdentifierService identifierService, IAssets assets, IExperienceCalculatorService experienceCalculatorService)
        {
            _experienceCalculatorService = experienceCalculatorService;
            _assets = assets;
            _identifierService = identifierService;

            Warmup();
        }

        private void Warmup()
        {
            _assets.LoadAsync<GameObject>(PLAYER_PATH);
        }

        public GameEntity CreatePlayer(Vector3 position)
        {
            return CreateEntity.Empty()
                .AddId(_identifierService.Next())
                .With(x => x.isPlayer = true)
                .AddViewPath(PLAYER_PATH)
                .AddTeam(Team.Player)
                .With(x => x.isAlive = true)

                .SetRigidbodyMovement(3f)
                .AddWorldPosition(Vector2.zero)
                .AddLookDirection(Vector2.zero)

                .AddPickupRadius(4f)
                .AddExperience(0)
                .AddMaxExperience(_experienceCalculatorService.CalculateMaxExperience(1))
                .AddLevel(1)

                .AddHealth(1000)
                .AddMaxHealth(1000)

                .SetVision(8f, 0.15f, Layers.Enemy)

                .AddBaseStats(new StatsData(CreateBaseStats()))
                .AddStatsModifiers(new StatsData());
        }

        private Stats CreateBaseStats() =>
            new()
            {
                maxHealth = 1000,
                movementSpeed = 3f,
                movementSpeedMultiplier = 1f,
                damageMultiplier = 1f
            };
    }
}
