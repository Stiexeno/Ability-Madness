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

        public static GameEntity SetForwardMovement(this GameEntity gameEntity)
        {
            return gameEntity
                .With(x => x.isForwardMovement = true);
        }

        public static GameEntity SetZigZagMovement(this GameEntity gameEntity, Vector2 direction)
        {
            return gameEntity
                .With(x => x.isZigZagMovement = true)
                .With(x => x.isForwardMovement = true)

                .AddZigZagTimeElapsed(0f)
                .AddZigZagDirection(direction);
        }
    }
}
