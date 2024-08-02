using UnityEngine;

namespace AbilityMadness.Code.Gameplay.Modifiers
{
    public static class ModifierExtensions
    {
        public static Vector2 GetMultishotDirection(Vector2 direction, int amount, int index)
        {
            var angleBetweenProjectiles = 45f / amount;
            var startAngle = -angleBetweenProjectiles * (amount - 1f) / 2f;

            // Shoot projectiles in arc like shotgun, without random
            var currentAngle = startAngle + index * angleBetweenProjectiles;
            var rotatedDirection = Quaternion.Euler(0, 0, currentAngle) * direction;

            return rotatedDirection;
        }
    }
}
