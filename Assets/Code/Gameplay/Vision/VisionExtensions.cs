using System.Collections.Generic;
using AbilityMadness.Code.Extensions;

namespace AbilityMadness.Code.Gameplay.Vision
{
    public static class VisionExtensions
    {
        public static GameEntity SetVision(this GameEntity gameEntity, float radius, float interval, int layer)
        {
            return gameEntity
                .With(x => x.isVision = true)
                .AddTargetsInSight(new List<int>(64))
                .AddVisionRadius(radius)
                .AddVisionLayer(layer)
                .AddVisionInterval(interval)
                .AddVisionTimer(0f);
        }
    }
}
