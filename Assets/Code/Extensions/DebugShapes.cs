using UnityEngine;

namespace AbilityMadness.Code.Editor
{
    public static class DebugShapes
    {
        public static void DrawCircle(Vector3 center, Vector3 normal, float radius, int segments, Color color)
        {
            if (segments < 3) segments = 3;

            Vector3 up = Vector3.up;
            if (Vector3.Dot(normal, up) > 0.99f)
            {
                up = Vector3.right;
            }

            Vector3 tangent = Vector3.Cross(normal, up).normalized * radius;

            float angleStep = 360f / segments;
            Quaternion rotation = Quaternion.AngleAxis(angleStep, normal);

            Vector3 prevPoint = center + tangent;
            for (int i = 0; i <= segments; i++)
            {
                Vector3 nextPoint = center + rotation * (prevPoint - center);
                Debug.DrawRay(prevPoint, nextPoint - prevPoint, color);
                prevPoint = nextPoint;
            }
        }
    }
}
