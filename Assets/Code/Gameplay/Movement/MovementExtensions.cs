using AbilityMadness.Code.Extensions;
using UnityEngine;

namespace AbilityMadness.Code.Gameplay.Movement
{
    public static class MovementExtensions
    {
        public static GameEntity SetRigidbodyMovement(this GameEntity gameEntity, float movementSpeed)
        {
            return gameEntity
                .With(x => x.isRigidbodyMovement = true)
                .AddDirection(Vector2.zero)
                .AddVelocity(Vector2.zero)
                .AddMovementSpeed(movementSpeed);
        }

        public static GameEntity SetForwardMovement(this GameEntity gameEntity, float movementSpeed)
        {
            return gameEntity
                .With(x => x.isForwardMovement = true)
                .With(x => x.isTransformMovement = true)
                .AddMovementSpeed(movementSpeed);
        }
    }
}
