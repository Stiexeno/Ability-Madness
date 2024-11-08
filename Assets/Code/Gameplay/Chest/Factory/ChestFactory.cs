﻿using AbilityMadness.Code.Common;
using AbilityMadness.Code.Extensions;
using AbilityMadness.Code.Infrastructure.Identifiers;

namespace AbilityMadness.Code.Gameplay.Chest.Factory
{
    public class ChestFactory : IChestFactory
    {
        private IIdentifierService _identifierService;

        public ChestFactory(IIdentifierService identifierService)
        {
            _identifierService = identifierService;
        }

        public GameEntity Create()
        {
            return CreateEntity.Empty()
                .AddId(_identifierService.Next())
                .With(x => x.isChest = true);
        }
    }
}
