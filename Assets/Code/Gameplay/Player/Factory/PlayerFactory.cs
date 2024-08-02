using AbilityMadness.Code.Common;
using AbilityMadness.Code.Extensions;
using AbilityMadness.Code.Gameplay.Health;
using AbilityMadness.Code.Gameplay.Movement;
using AbilityMadness.Code.Gameplay.Vision;
using AbilityMadness.Code.Infrastructure.Services.Identifiers;
using AbilityMadness.Infrastructure.Services.Assets;
using UnityEngine;

namespace AbilityMadness.Factory
{
    public class PlayerFactory : IPlayerFactory
    {
        private const string PlayerPath = "Character_Player";

        private IIdentifierService _identifierService;
        private IAssets _assets;

        public PlayerFactory(IIdentifierService identifierService, IAssets assets)
        {
            _assets = assets;
            _identifierService = identifierService;

            Warmup();
        }

        private void Warmup()
        {
            _assets.LoadAsync<GameObject>(PlayerPath);
        }

        public GameEntity CreatePlayer(Vector3 position)
        {
            return CreateEntity.Empty()
                .AddId(_identifierService.Next())
                .With(x => x.isPlayer = true)
                .AddViewPath(PlayerPath)
                .AddTeam(Team.Player)
                .With(x => x.isAlive = true)

                .SetRigidbodyMovement(300f)
                .AddWorldPosition(Vector2.zero)
                .AddLookDirection(Vector2.zero)

                .AddPickupRadius(7f)
                .AddExperience(0)
                .AddMaxExperience(100)

                .SetVision(8f, 1f, Constants.Layers.Enemy);
        }
    }
}
