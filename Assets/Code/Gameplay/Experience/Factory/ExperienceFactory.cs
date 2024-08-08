using System;
using AbilityMadness.Code.Common;
using AbilityMadness.Code.Extensions;
using AbilityMadness.Code.Infrastructure.Services.Identifiers;
using UnityEngine;

namespace AbilityMadness.Code.Gameplay.Experience.Factory
{
    public class ExperienceFactory : IExperienceFactory
    {
        private IIdentifierService _identifierService;

        public ExperienceFactory(IIdentifierService identifierService)
        {
            _identifierService = identifierService;
        }

        public GameEntity CreateExperience(ExperienceTypeId type, Vector3 position)
        {
            switch (type)
            {
                case ExperienceTypeId.Unknown:
                    throw new ArgumentOutOfRangeException(nameof(type), type, null);
                case ExperienceTypeId.Green:
                    return CreateGreenExperience(position);
                default:
                    throw new ArgumentOutOfRangeException(nameof(type), type, null);
            }
        }

        private GameEntity CreateGreenExperience(Vector3 position)
        {
            return CreateEntity.Empty()
                .AddId(_identifierService.Next())
                .AddViewPath(Constants.Prefabs.Experiences.Green)
                .AddExperienceTypeId(ExperienceTypeId.Green)
                .AddExperience(10)
                .AddMovementSpeed(0.1f)

                .With(x => x.isTransformMovement = true)
                .AddWorldPosition(position);
        }
    }
}