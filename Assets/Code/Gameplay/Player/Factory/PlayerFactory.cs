﻿using AbilityMadness.Code.Common;
using AbilityMadness.Code.Extensions;
using AbilityMadness.Code.Gameplay.Health;
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

                .AddWorldPosition(Vector2.zero)
                .AddVelocity(Vector2.zero)
                .AddDirection(Vector2.zero)
                .AddLookDirection(Vector2.zero)
                .AddMovementSpeed(300f)
                .With(x => x.isRigidbodyMovement = true)

                .With(x => x.isRangedAttack = true);
        }
    }
}
