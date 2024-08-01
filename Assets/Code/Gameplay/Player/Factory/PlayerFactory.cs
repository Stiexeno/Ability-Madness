using AbilityMadness.Code.Common;
using AbilityMadness.Code.Extensions;
using AbilityMadness.Code.Gameplay.Health;
using AbilityMadness.Code.Gameplay.Movement;
using AbilityMadness.Code.Gameplay.Vision;
using AbilityMadness.Code.Infrastructure.Services.Identifiers;
using UnityEngine;

namespace AbilityMadness.Factory
{
    public class PlayerFactory : IPlayerFactory
    {
        private const string PlayerPath = "Character_Player";

        private IIdentifierService _identifierService;

        public PlayerFactory(IIdentifierService identifierService)
        {
            _identifierService = identifierService;
        }

        public GameEntity CreatePlayer(Vector3 position)
        {
            return CreateEntity.Empty()
                .AddId(_identifierService.Next())
                .With(x => x.isPlayer = true)
                .AddViewPath(PlayerPath)
                .AddTeam(Team.Player)

                .SetRigidbodyMovement(300f)
                .AddWorldPosition(Vector2.zero)
                .AddLookDirection(Vector2.zero)

                .SetVision(10f, 1f, Constants.Layers.Enemy);
        }
    }
}
