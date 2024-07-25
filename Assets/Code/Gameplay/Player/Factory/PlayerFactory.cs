using AbilityMadness.Code.Common;
using AbilityMadness.Code.Extensions;
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
                .AddIdentifier(_identifierService.Next())
                .With(x => x.isPlayer = true)
                .AddViewPath(PlayerPath)

                .AddWorldPosition(Vector2.zero)
                .AddVelocity(Vector2.zero)
                .AddDirection(Vector2.zero)
                .AddLookDirection(Vector2.zero)
                .AddMovementSpeed(50f)
                .With(x => x.isRigidbodyMovement = true);
        }
    }
}
