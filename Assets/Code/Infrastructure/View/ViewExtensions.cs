using UnityEngine;

namespace AbilityMadness.Code.Infrastructure.View
{
    public static class ViewExtensions
    {
        public static string GetViewPath(this EntityView entityView)
        {
            if (entityView.Entity != null)
                return entityView.Entity.ViewPath;

            Debug.LogError("Entity is null");
            return string.Empty;
        }

        public static string GetViewPath(this GameEntity entity)
        {
            return entity.ViewPath;
        }
    }
}
