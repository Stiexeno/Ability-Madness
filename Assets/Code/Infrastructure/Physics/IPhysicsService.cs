using System.Collections.Generic;
using UnityEngine;

namespace AbilityMadness.Code.Infrastructure.Physics
{
    public interface IPhysicsService
    {
        IEnumerable<GameEntity> RaycastAll(Vector2 worldPosition, Vector2 direction, int layerMask);
        GameEntity Raycast(Vector2 worldPosition, Vector2 direction, float distance, int layerMask);
        GameEntity LineCast(Vector2 start, Vector2 end, int layerMask);
        IEnumerable<GameEntity> CircleCast(Vector3 position, float radius, int layerMask);
        int CircleCastNonAlloc(Vector3 position, float radius, int layerMask, GameEntity[] hitBuffer);
        TEntity OverlapPoint<TEntity>(Vector2 worldPosition, int layerMask) where TEntity : class;
    }
}
