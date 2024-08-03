using UnityEngine;

namespace AbilityMadness.Code.Extensions
{
    public static class VectorExtensions
    {
        public static Vector2 GetSpreadDirection(Vector2 direction, int amount, int index)
        {
            var angleBetweenProjectiles = 45f / amount;
            var startAngle = -angleBetweenProjectiles * (amount - 1f) / 2f;

            var currentAngle = startAngle + index * angleBetweenProjectiles;
            var rotatedDirection = Quaternion.Euler(0, 0, currentAngle) * direction;

            return rotatedDirection;
        }

        public static Vector3 ToVector3(this Vector2 vector2)
        {
            return new Vector3(vector2.x, vector2.y, 0);
        }

        public static Vector2 ToVector2(this Vector3 vector3)
        {
            return new Vector2(vector3.x, vector3.y);
        }

        public static Vector2 AddX(this Vector2 vector2, float x)
        {
            return new Vector2(vector2.x + x, vector2.y);
        }

        public static Vector2 AddY(this Vector2 vector2, float y)
        {
            return new Vector2(vector2.x, vector2.y + y);
        }

        public static Vector3 AddX(this Vector3 vector2, float x)
        {
            return new Vector3(vector2.x + x, vector2.y, vector2.z);
        }

        public static Vector3 AddY(this Vector3 vector2, float y)
        {
            return new Vector3(vector2.x, vector2.y + y, vector2.z);
        }

        public static Vector3 AddZ(this Vector3 vector2, float z)
        {
            return new Vector3(vector2.x, vector2.y, vector2.z + z);
        }
    }
}
