using UnityEngine;

namespace AbilityMadness.Code.Extensions
{
    public static class VectorExtensions
    {
        public static Vector3 ToVector3(this Vector2 vector2)
        {
            return new Vector3(vector2.x, vector2.y, 0);
        }
    }
}
