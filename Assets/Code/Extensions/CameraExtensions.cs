using UnityEngine;

namespace AbilityMadness.Code.Extensions
{
    public static class CameraExtensions
    {
        public static Vector3 GetRandomPositionOutsideScreen(float maxDistance)
        {
            // Get the screen bounds in world coordinates
            Vector2 screenMin = Camera.main.ViewportToWorldPoint(new Vector2(0, 0));
            Vector2 screenMax = Camera.main.ViewportToWorldPoint(new Vector2(1, 1));

            // Randomly choose one of the four screen edges
            int edge = Random.Range(0, 4);
            Vector2 position = Vector2.zero;

            switch (edge)
            {
                case 0: // Top edge
                    position = new Vector2(Random.Range(screenMin.x, screenMax.x), screenMax.y);
                    position += Vector2.up * Random.Range(0, maxDistance);
                    break;
                case 1: // Bottom edge
                    position = new Vector2(Random.Range(screenMin.x, screenMax.x), screenMin.y);
                    position += Vector2.down * Random.Range(0, maxDistance);
                    break;
                case 2: // Left edge
                    position = new Vector2(screenMin.x, Random.Range(screenMin.y, screenMax.y));
                    position += Vector2.left * Random.Range(0, maxDistance);
                    break;
                case 3: // Right edge
                    position = new Vector2(screenMax.x, Random.Range(screenMin.y, screenMax.y));
                    position += Vector2.right * Random.Range(0, maxDistance);
                    break;
            }

            return position;
        }
    }
}
